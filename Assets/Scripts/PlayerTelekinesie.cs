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
        // Montrer via de l'UI que la t�l�kin�sie est activ�
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
            Debug.DrawLine(ray.origin, hit.point, Color.red, 5f);
            rigidbodyObject.AddForceAtPosition(hit.point, hit.point, ForceMode.Force);
        }
    }
}