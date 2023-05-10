using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTelekinesie : MonoBehaviour
{
    #region Variables
    [Header("Telekinesy Parameters")]
    public bool telekinesyOn;
    public GameObject telekinesyObject;
    public Rigidbody rigidbodyObject;
    public Collider colObject;

    public float forceVariable;

    [Header("Player Component")]
    private PlayerInputManager playerInput;

    public bool selected = false;

    public Camera cameraPlayer;

    public LayerMask layerGround;

    #endregion


    private void Awake()
    {
        playerInput = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        EnableTelekinesie();
        MoveObject();
        // Montrer via de l'UI que la télékinésie est activé
        //Debug.Log(playerInput.CanTelekinesy);
    }

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

    private void MoveObject()
    {
        if (telekinesyOn == false) return;
        if (!telekinesyObject) return;

        RaycastHit hit;
        Ray ray = cameraPlayer.ScreenPointToRay(playerInput.MousePosition);

        if (Physics.Raycast(ray, out hit, 99, layerGround))
        {
            Debug.Log("Here");
            Debug.DrawLine(ray.origin, hit.point, Color.red, 5f);
            Vector3 force = hit.point - ray.origin;

            rigidbodyObject.AddForceAtPosition(force.normalized * forceVariable , hit.point, ForceMode.Force);
            
            /*
            Vector3 current = transform.position;
            Vector3 nextLerp = Vector3.Lerp(current, hit.point, Time.deltaTime);

            transform.position = nextLerp;
            */
        }
        else
        {

        }
    }
}