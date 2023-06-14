using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.VFX;

public class PlayerTelekinesie : MonoBehaviour
{
    #region Variables
    [Header("Telekinesy Parameters")]
    public bool telekinesyOn;
    public GameObject telekinesyObject;
    public Rigidbody rigidbodyObject;
    public Collider colObject;

    public float forceVariable;
    public float timeToLerp = 5;

    float currentHeight = 0;

    public float maxHeigtPlayer = 5f;

    public VisualEffect telekinesieEffect;

    [Header("Player Component")]
    private PlayerInputManager playerInput;
    public bool selected = false;
    public Camera cameraPlayer;
    public LayerMask layerGround;
    public Animator animator;

    [Header("IK")]
    public GameObject targetIK;
    public TwoBoneIKConstraint ikLeftHand;
    public GameObject dummyIkLookAt;
    public Vector2 lookAtDummy;
    public MultiAimConstraint aimConstraint;
    private float lookWeight;

    #endregion


    private void Awake()
    {
        playerInput = GetComponent<PlayerInputManager>();
        telekinesieEffect.Stop();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        EnableTelekinesie();
        MoveObject();

        if (ikLeftHand == null) return;

        if (CanLookTargetIK())
        {
            ikLeftHand.weight = Mathf.Clamp(ikLeftHand.weight + Time.deltaTime, 0, 1);
        }
        else
        {
            ikLeftHand.weight = Mathf.Clamp(ikLeftHand.weight - Time.deltaTime, 0, 1);
        }


        // Montrer via de l'UI que la télékinésie est activé
        //Debug.Log(playerInput.CanTelekinesy);
    }


    private void OnAnimatorIK(int layerIndex)
    {
        if (CanLookTargetIK())
        {
            lookWeight = Mathf.Lerp(lookWeight, 1, Time.deltaTime);
            animator.SetLookAtWeight(lookWeight);

        }
        else
        {
            lookWeight = Mathf.Lerp(lookWeight, 0, Time.deltaTime);
            animator.SetLookAtWeight(lookWeight);
        }

        animator.SetLookAtPosition(targetIK.transform.position);
    }

    private bool CanLookTargetIK()
    {
        if (telekinesyOn == false) return false;
        if (!telekinesyObject) return false;
        if (!dummyIkLookAt) return false;

        dummyIkLookAt.transform.LookAt(targetIK.transform.position);
        float pivotRotY = dummyIkLookAt.transform.localRotation.y;

        if (pivotRotY > lookAtDummy.x || pivotRotY < lookAtDummy.y)
        {
            return true;
        }
        else return false;
    }


    /// <summary>
    /// Enable telekinesie for player
    /// </summary>
    private void EnableTelekinesie()
    {
        if (playerInput.CanTelekinesy)
        {
            if (telekinesyOn)
            {
                telekinesyOn = false;
                RemoveTelekinesieObject();
            }
            else
            {
                telekinesyOn = true;
            }

            playerInput.CanTelekinesy = false;
        }
    }


    /// <summary>
    /// Add the object to the telekinesie
    /// </summary>
    /// <param name="objectToAdd"></param>
    public void AddObjectTelekinesie(GameObject objectToAdd)
    {

        selected = true;
        telekinesyObject = objectToAdd;
        rigidbodyObject = objectToAdd.GetComponent<Rigidbody>();
        colObject = objectToAdd.GetComponent<Collider>();

        rigidbodyObject.isKinematic = true;
        rigidbodyObject.useGravity = false;

        if (!aimConstraint) return;
        StopAllCoroutines();
        StartCoroutine(AddWeightDataIK());

        if (telekinesieEffect)
            telekinesieEffect.Play();
    }


    /// <summary>
    /// Remove the telekinesie object
    /// </summary>
    public void RemoveTelekinesieObject()
    {
        rigidbodyObject.isKinematic = false;
        rigidbodyObject.useGravity = true;

        selected = false;
        telekinesyObject = null;
        rigidbodyObject = null;
        colObject = null;

        if (!aimConstraint) return;
        StopAllCoroutines();
        StartCoroutine(RemoveWeightDataIK());

        if (telekinesieEffect)
            telekinesieEffect.Stop();

    }

    #region IK TORSE

    /// <summary>
    /// Lerp for smooth the weight DataIK
    /// </summary>
    /// <param name="weight"></param>
    /// <returns></returns>
    private IEnumerator AddWeightDataIK()
    {
        WeightedTransformArray a = aimConstraint.data.sourceObjects;

        float i = 0;

        while (i <= 1)
        {
            i = i + Time.deltaTime * timeToLerp;
            a.SetWeight(0, i);
            aimConstraint.data.sourceObjects = a;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    /// <summary>
    /// Lerp for smooth the weight DataIK
    /// </summary>
    /// <param name="weight"></param>
    /// <returns></returns>
    private IEnumerator RemoveWeightDataIK()
    {
        WeightedTransformArray a = aimConstraint.data.sourceObjects;

        float i = 1;

        while (i >= 0)
        {
            i = i - Time.deltaTime * timeToLerp;
            a.SetWeight(0, i);
            aimConstraint.data.sourceObjects = a;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    #endregion

    /// <summary>
    /// Move object along mouse position of the player with offset heigth
    /// </summary>
    private void MoveObject()
    {
        if (telekinesyOn == false) return;
        if (!telekinesyObject) return;

        RaycastHit hit;
        Ray ray = cameraPlayer.ScreenPointToRay(playerInput.MousePosition);

        if (Physics.Raycast(ray, out hit, 99, layerGround))
        {
            //IK
            targetIK.transform.position = telekinesyObject.transform.position;

            //Math et physique pour trouver la bonne position et smooth le tout
            currentHeight += playerInput.ScrollMouse * Time.deltaTime * forceVariable;

            currentHeight = Mathf.Clamp(currentHeight, 1f, maxHeigtPlayer);

            Vector3 offsetHeight = new Vector3(hit.point.x, hit.point.y + currentHeight, hit.point.z);

            Vector3 currentPos = telekinesyObject.transform.position;

            Vector3 nextPos = Vector3.Lerp(currentPos, offsetHeight, Time.deltaTime * timeToLerp);

            //Vector3 force = offsetHeight - ray.origin;

            //rigidbodyObject.AddForceAtPosition(force.normalized * forceVariable, hit.point, ForceMode.Force);

            //Deplace l'object
            rigidbodyObject.MovePosition(nextPos);

        }
        else
        {

        }
    }
}