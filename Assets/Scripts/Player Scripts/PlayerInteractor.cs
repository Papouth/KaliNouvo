using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerInteractor : MonoBehaviour
{
    public static PlayerInteractor playerInteractorInstance;

    public Transform interactionPoint;
    public float radius;
    public LayerMask interactableLayer;
    public int interactableCount;

    [Header("Composant")]
    public Collider[] colliders;
    public IInteractable interactable;

    [HideInInspector] public PlayerInputManager playerInput;
    public GameObject hands;

    [Header("UI")]
    public UIDocument interactionMenu;
    private Label textLabel;
    public VisualElement rootInteraction;

    public InputActionReference playerAction;

    public bool disableUI;

    public bool cutSceneInteract;

    public TwoBoneIKConstraint leftHands;

    private void Awake()
    {
        playerInteractorInstance = this;
        playerInput = GetComponent<PlayerInputManager>();

        rootInteraction = interactionMenu.rootVisualElement;

        textLabel = rootInteraction.Q<Label>("InteractionText");

        textLabel.text = InputControlPath.ToHumanReadableString(
                playerAction.action.bindings[0]
                .effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        rootInteraction.style.display = DisplayStyle.None;
    }

    public virtual void Update()
    {
        Detector();
    }

    /// <summary>
    /// Détecte la présence d'interactable autour du joueurs
    /// </summary>
    public virtual void Detector()
    {
        if (cutSceneInteract)
        {
            rootInteraction.style.display = DisplayStyle.None;
            return;
        }

        interactableCount = Physics.OverlapSphereNonAlloc(interactionPoint.position, radius, colliders, interactableLayer);

        // On Interagis
        if (interactableCount > 0)
        {
            if (!disableUI && rootInteraction != null)
            {
                rootInteraction.style.display = DisplayStyle.Flex;
            }

            if (playerInput.CanInteract)
            {
                interactable = NearestCollider(colliders);

                if (interactable != null) //Sécurité au cas ou
                {
                    //Debug.Log("here" + interactable);
                    interactable.Interact();
                    rootInteraction.style.display = DisplayStyle.None;
                    disableUI = true;
                }
                playerInput.CanInteract = false;
                interactable = null;
            }

        }
        else
        {
            playerInput.CanInteract = false;
            interactable = null;
            rootInteraction.style.display = DisplayStyle.None;
            disableUI = false;
        }
    }

    /// <summary>
    /// Desactive le document d'interaction
    /// </summary>
    /// <param name="isAcitve">true = activé, false = desactive</param>
    public void DisableUIDocument(bool isAcitve)
    {
        cutSceneInteract = isAcitve;
    }


    /// <summary>
    /// Le collider le plus proche du joueur selon un radius et un layer
    /// </summary>
    /// <param name="cols"></param>
    /// <returns></returns>
    private IInteractable NearestCollider(Collider[] cols)
    {
        float nearestInteractable = 9999;
        Collider nearestCol = null;

        foreach (Collider col in cols)
        {
            if (col == null) continue;

            float currentDistance = Vector3.Distance(col.transform.position, transform.position);
            if (currentDistance <= nearestInteractable)
            {
                nearestInteractable = currentDistance;
                nearestCol = col;
            }
        }
        if (nearestCol.GetComponent(typeof(IInteractable)) != null)
        {
            return nearestCol.GetComponent<IInteractable>();
        }
        else return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionPoint.position, radius);
    }

    public void EnableIKHands()
    {
        StartCoroutine(EnableHandIKCoroutine());
    }

    public void DisableIKHands()
    {
        StartCoroutine(DisableHandIKCoroutine());
    }

    public IEnumerator EnableHandIKCoroutine()
    {
        float i = 0;

        while (i <= 1)
        {
            i = i + Time.deltaTime * 2f;
            leftHands.weight = i;

            yield return new WaitForSeconds(Time.deltaTime * 2f);
        }
    }
    public IEnumerator DisableHandIKCoroutine()
    {
        float i = 1;

        while (i >= 0)
        {
            i = i - Time.deltaTime * 2f;
            leftHands.weight = i;

            yield return new WaitForSeconds(Time.deltaTime * 2f);
        }
    }

}