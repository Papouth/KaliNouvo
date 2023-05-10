using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.LowLevel;

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

    [Header("Player Component")]
    private PlayerInputManager playerInput;
    public bool selected = false;
    public Camera cameraPlayer;
    public LayerMask layerGround;


    public GameObject targetIK;
    public TwoBoneIKConstraint ikLeftHand;
    public GameObject dummyIkLookAt;
    public Vector2 lookAtDummy;

    #endregion


    private void Awake()
    {
        playerInput = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        EnableTelekinesie();
        MoveObject();

        if (LookPlayerIK())
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
        
    }

    private bool LookPlayerIK()
    {
        if (telekinesyOn == false) return false;
        if (!telekinesyObject) return false;

        dummyIkLookAt.transform.LookAt(targetIK.transform.position);
        float pivotRotY = dummyIkLookAt.transform.localRotation.y;
        Debug.Log(pivotRotY);

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
            }
            else
            {
                telekinesyOn = true;
            }

            playerInput.CanTelekinesy = false;
        }
    }

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