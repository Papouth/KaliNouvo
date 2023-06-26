using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [Header("Player Movement")]
    public float moveSpeed = 3f;
    private float currentSpeed;
    public float climbSpeedReducer = 2.2f;
    [SerializeField] private float climbJumpBuffer;
    public Vector3 directionInput;
    private Vector3 movement;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity = 0.1f;

    [Header("Player Ground")]
    public RaycastCheck[] raycastsGrounds;
    public LayerMask layersGround;
    public float rangeMaxGrounded;
    public float stepGround = -.1f;

    [Header("SteepSlopeCheck")]
    public float raycastLenghtCheck;
    RaycastHit slopeHit;

    [Header("Player Jump")]
    public float jumpForce = 2f;
    private float ySpeed = 0;
    private float coyoteTime = 0;
    [SerializeField] private float coyoteTimer = .5f;

    [Header("Crouch")]
    public float crouchWalkSpeed = 3f;
    public float crouchSpeedHeight = .3f;
    public float standHeight = 2.0f;
    public float crouchHeight = 1.0f;
    public RaycastCheck[] raycastCanStandUp;
    public LayerMask layersCanStandUp;
    public float rangeMaxStandUp = 1.05f;
    public float centerZ;
    public bool inCrouch;
    private float desiredHeight;

    [Header("Climb Parameters")]
    //public bool haveClimbed;
    //[SerializeField] private bool haveClimbJumped;
    [SerializeField] private float climbJumpTimer;
    [SerializeField] private float climbUpAnimation;
    [SerializeField] private bool climbingSecurityTimer;
    [SerializeField] private float timeBeforeClimbJump;


    [Header("Player Component")]
    public Camera cam;
    public CharacterController cc;
    private PlayerInputManager playerInput;
    public Animator animator;
    private PlayerNewClimbSystem playerNewClimbSystem;

    public AudioSource audioFoot;
    public AudioClip[] audioFootList; 
    #endregion

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInputManager>();
        animator = GetComponent<Animator>();
        playerNewClimbSystem = GetComponent<PlayerNewClimbSystem>();

        foreach (RaycastCheck raycast in raycastsGrounds)
        {
            raycast.layer = layersGround;
            raycast.rangeMax = rangeMaxGrounded;
            raycast.directionRaycast = Vector3.down;
        }

        foreach (RaycastCheck raycast in raycastCanStandUp)
        {
            raycast.layer = layersCanStandUp;
            raycast.rangeMax = rangeMaxStandUp;
            raycast.directionRaycast = Vector3.up;
        }
    }

    private void Start()
    {
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        Jump();

        Locomotion();

        DropDown();

        ClimbCross();

        //if (OnSteepSlope()) SteepSlopeMovement();

        Crouching();

        SetAnimator();
    }

    #region PlayerMove

    /// <summary>
    /// Gere le deplacement du personnage avec le character controller
    /// </summary>
    public void Locomotion()
    {
        if (!playerInput) return;

        directionInput.Set(playerInput.MoveInput.x, 0, playerInput.MoveInput.y);

        if (directionInput.magnitude >= 0.1f && !playerNewClimbSystem.isClimbing)
        {
            float targetAngle = Mathf.Atan2(directionInput.x, directionInput.z) * Mathf.Rad2Deg +
                cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            directionInput = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        if (!playerNewClimbSystem.isClimbing)
        {
            movement = directionInput.normalized * (currentSpeed * Time.deltaTime);
        }
        else
        {
            // On inverse les controles lors du climb et on viens réduire la vitesse de déplacement du joueur
            movement = directionInput.normalized * (moveSpeed / climbSpeedReducer * Time.deltaTime);
            movement = transform.TransformDirection(movement);

            // Redirection du joueur face au mur
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(0f, 1f, 0f)), transform.forward, out hit, 1f))
            {
                // On rotate le joueur correctement vers le mur
                if (hit.normal == new Vector3(0f, 0f, 1f)) transform.rotation = Quaternion.Euler(0, 180, 0);
                else transform.rotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);
            }
        }
    }

    #region Climb Drop
    /// <summary>
    /// Si on appuie sur S en climb, alors on descend
    /// </summary>
    private void DropDown()
    {
        if (directionInput.z <= -0.1 && playerNewClimbSystem.isClimbing)
        {
            playerNewClimbSystem.isClimbing = false;
        }
    }

    /// <summary>
    /// Permet d'escalader en appuyant sur la touche avancer
    /// </summary>
    private void ClimbCross()
    {
        if (directionInput.z >= 0.1 && playerNewClimbSystem.isClimbing)
        {
            playerNewClimbSystem.isClimbing = false;
            cc.enabled = false;
            animator.applyRootMotion = true;
            animator.SetTrigger("TrClimbCross");
            StartCoroutine(CrossTimer());
        }
    }

    private IEnumerator CrossTimer()
    {
        yield return new WaitForSeconds(1.4f);//1.05
        cc.enabled = true;
        animator.applyRootMotion = false;
        animator.ResetTrigger("TrClimbCross");
    }
    #endregion

    private bool OnSteepSlope()
    {
        float indicRaycastCheck = 0;
        foreach (RaycastCheck raycast in raycastsGrounds)
        {
            if (Physics.Raycast(raycast.transform.position, Vector3.down, out slopeHit, raycastLenghtCheck, layersGround))
            {
                Debug.DrawLine(raycast.transform.position, Vector3.down * raycastLenghtCheck + raycast.transform.position, Color.blue);
                float slopeAngle = Vector3.Angle(slopeHit.normal, Vector3.up);

                if (slopeAngle > cc.slopeLimit)

                    indicRaycastCheck++;
            }
        }

        if (indicRaycastCheck > 0)
        {
            return true;
        }
        return false;
    }

    private void SteepSlopeMovement()
    {
        Vector3 slopeDirection = Vector3.up - slopeHit.normal * Vector3.Dot(Vector3.up, slopeHit.normal);
        float slideSpeed = currentSpeed + Time.deltaTime;

        movement = slopeDirection * -slideSpeed;
        movement.y = movement.y - slopeHit.point.y;

        cc.Move(movement * Time.deltaTime);
    }
    #endregion

    #region PlayerJump

    /// <summary>
    /// Activation du jump
    /// </summary>
    public void Jump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // Au sol
        if (isGrounded())
        {
            //Fonction Check Step Slope ground Return bool
            //=> Fonction Check step slope void 
            animator.SetBool("Ground", true);

            if (ySpeed <= stepGround)
            {
                ySpeed = -.2f;
                //ySpeed = cc.velocity.y;
            }

            if (playerInput.CanJump)
            {
                animator.SetTrigger("TrJump");

                ySpeed = jumpForce;

                coyoteTime = coyoteTimer;
            }
        }
        else
        {
            animator.SetBool("Ground", false);
            if (ySpeed <= -50)
            {
                ySpeed = -50;
            }
        }

        // En état de climb
        if (playerNewClimbSystem.isClimbing && !climbingSecurityTimer)
        {
            playerInput.CanClimbJump = false;
            // Sécurité afin d'éviter un double jump
            Invoke("ClimbSecurityChecker", timeBeforeClimbJump);
        }
        else if (playerNewClimbSystem.isClimbing && playerInput.CanClimbJump && climbingSecurityTimer)
        {
            climbingSecurityTimer = false;

            playerNewClimbSystem.isClimbing = false;
            animator.applyRootMotion = true;

            // Sécurité animator
            animator.SetBool("ClimbBool", false);

            animator.ResetTrigger("TrClimbJump");
            animator.SetTrigger("TrClimbJump");

            StartCoroutine(ClimbJumpTimer());

            ySpeed = jumpForce * climbJumpBuffer;
        }
        else if (!playerNewClimbSystem.isClimbing)
        {
            // Si le joueur n'est plus en climb on reset en faux
            climbingSecurityTimer = false;
        }

        movement.y = ySpeed * Time.deltaTime;

        cc.Move(movement);
    }

    private void ClimbSecurityChecker()
    {
        climbingSecurityTimer = true;
    }

    /// <summary>
    /// Refaire un saut pendant le climb
    /// </summary>
    /// <returns></returns>
    private IEnumerator ClimbJumpTimer()
    {
        yield return new WaitForSeconds(climbJumpTimer * 1.1f);

        // Sécurité animator
        animator.ResetTrigger("TrClimbJump");

        animator.applyRootMotion = false;
        playerInput.CanClimbJump = false;
    }

    /// <summary>
    /// Check si le joueur est au sol
    /// </summary>
    /// <returns></returns>
    public bool isGrounded()
    {
        int raycastGood = 0;

        foreach (RaycastCheck raycast in raycastsGrounds)
        {
            if (raycast.RaycastTest()) raycastGood++;
        }


        if (raycastGood > 0) //La je touche le sol
        {
            animator.ResetTrigger("TrJump");
            animator.ResetTrigger("TrClimbJump");

            coyoteTime = 0;
            return true;
        }
        else  //La je touche plus le sol
        {
            coyoteTime += Time.deltaTime;

            if (coyoteTime >= coyoteTimer) //Temps écoulé
            {
                // On empeche le joueur de re-sauter instantanement au contact du sol
                playerInput.CanJump = false;
                return false;
            }
            else return true; //Encore le temps de sauté
        }
    }
    
    #endregion

    #region PlayerCrouched

    /// <summary>
    /// Ajuste la taille du joueur selon l'input
    /// </summary>
    private void Crouching()
    {
        if (!playerNewClimbSystem.isClimbing)
        {
            if (playerInput.Crouching)
            {
                desiredHeight = crouchHeight;
                inCrouch = true;
                currentSpeed = crouchWalkSpeed;
            }
            else if (!playerInput.Crouching && CanStandUp())
            {
                desiredHeight = standHeight;
                inCrouch = false;
                currentSpeed = moveSpeed;
            }
        }

        if (cc.height != desiredHeight)
        {
            AdjustHeight(desiredHeight);
        }
    }

    private bool CanStandUp()
    {
        // On check si le joueur est accroupis
        int raycastGood = 0;

        foreach (RaycastCheck raycast in raycastCanStandUp)
            if (raycast.RaycastTest()) raycastGood++;

        if (raycastGood > 0) return false;
        else return true;

    }

    /// <summary>
    /// Ajuste la taille du joueur via son collider
    /// </summary>
    /// <param name="height"></param>
    private void AdjustHeight(float height)
    {
        float center = height / 2;

        cc.height = Mathf.Lerp(cc.height, height, crouchSpeedHeight);
        cc.center = Vector3.Lerp(cc.center, new Vector3(0, center, centerZ), crouchSpeedHeight);
    }
    #endregion

    private void SetAnimator()
    {
        animator.SetFloat("Movement", directionInput.magnitude);
        animator.SetFloat("ClimbMove", directionInput.x);

        animator.SetBool("Crouch", inCrouch);
    }

    public void AudioFoot()
    {
        if (!audioFoot) return;
        if (audioFootList.Length == 0) return;

        Debug.Log("AudioFoot");

        int randomAudio = Random.Range(0, audioFootList.Length);

        audioFoot.clip = audioFootList[randomAudio];

        audioFoot.Play();
    }


    private void OnDrawGizmos()
    {
        foreach (RaycastCheck raycast in raycastsGrounds)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(raycast.transform.position, raycast.transform.position + Vector3.down * rangeMaxGrounded);
        }

        foreach (RaycastCheck raycast in raycastCanStandUp)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(raycast.transform.position, raycast.transform.position + Vector3.up * rangeMaxStandUp);
        }

        Debug.DrawRay(transform.position + transform.TransformDirection(new Vector3(0f, 1f, 0f)), transform.forward, Color.red);
    }
}