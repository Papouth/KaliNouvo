using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    #region Variables
    private Vector2 moveInput;
    private Vector2 mousePosition;
    private bool canJump;
    private bool crouching;
    private bool canInteract;
    private bool canChangeTempo;
    private bool canDestroy;
    private bool canOsmose;
    private bool canClimbJump;
    private bool canTelekinesy;
    private bool canSelect;
    private bool canMenu;

    public bool telekinesyKeyOn;

    private float scrollMouse;
    #endregion


    #region Bool Functions
    public Vector2 MoveInput => moveInput;
    public Vector2 MousePosition => mousePosition;

    public float ScrollMouse => scrollMouse;

    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
    public bool Crouching => crouching;
    public bool CanInteract
    {
        get { return canInteract; }
        set { canInteract = value; }
    }

    public bool ChangeTempo
    {
        get { return canChangeTempo; }
        set { canChangeTempo = value; }
    }

    public bool CanMenu
    {
        get { return canMenu; }
        set { canMenu = value; }
    }

    public bool CanDestroy
    {
        get { return canDestroy; }
        set { canDestroy = value; }
    }

    public bool CanOsmose
    {
        get { return canOsmose; }
        set { canOsmose = value; }
    }

    public bool CanClimbJump
    {
        get { return canClimbJump; }
        set { canClimbJump = value; }
    }

    public bool CanTelekinesy
    {
        get { return canTelekinesy; }
        set { canTelekinesy = value; }
    }

    public bool CanSelect
    {
        get { return canSelect; }
        set { canSelect = value; }
    }
    #endregion


    #region Functions
    public void OnMovement(InputValue value)
    {
        // On récupère la valeur du mouvement qu'on stock dans un Vector2
        moveInput = value.Get<Vector2>();
    }

    public void OnMousePosition(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    public void OnJump()
    {

        if (!crouching)
            // Récupération de l'input
            canJump = true;
    }

    public void OnCrouch()
    {
        crouching = !crouching;
    }

    public void OnInteract()
    {
        canInteract = true;
    }

    public void OnMenu()
    {
        canMenu = true;
    }

    public void OnTempo()
    {
        canChangeTempo = true;
    }

    public void OnBreak()
    {
        canDestroy = true;
        Invoke("BreakTimer", 0.1f);
    }

    private void BreakTimer()
    {
        canDestroy = false;
    }

    public void OnOsmose()
    {
        canOsmose = true;
    }

    public void OnClimbJump()
    {
        canClimbJump = true;
    }

    public void OnTelekinesy()
    {
        canTelekinesy = true;
        telekinesyKeyOn = true;
    }

    public void OnSelect()
    {
        canSelect = !canSelect;
    }

    private void OnScroll(InputValue value)
    {
        if (value.Get<float>() >= 1)
        {
            scrollMouse = 1;
        }
        else if (value.Get<float>() <= -1)
        {
            scrollMouse = -1;
        }
        else
        {
            scrollMouse = 0;
        }
    }
    #endregion
}