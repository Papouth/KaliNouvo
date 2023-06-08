using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftableObject : CustomsTriggers
{
    private PastToPresent pTp;

    public override void Start()
    {
        pTp = GetComponent<PastToPresent>();
        base.Start();
    }

    public override void Interact()
    {
        if (weight <= 20 && pTp.canLift)
        {
            GoToHand(playerInteractorDistance.hands, playerInteractorDistance.playerInput); // playerInteractor
        }

        return;
    }

    private void Update()
    {
        AntiTpWhenLifting();
    }

    /// <summary>
    /// Empeche le joueur de changer de tempo quand il a un objet en main
    /// </summary>
    private void AntiTpWhenLifting()
    {
        if (playerInteractorDistance.hands.transform.childCount == 0) GameManager.GM.canTP = false;
        else if (playerInteractorDistance.hands.transform.childCount > 0) GameManager.GM.canTP = true;
    }

    public void GoToHand(GameObject hands, PlayerInputManager playerInput)
    {
        if (playerInput.CanInteract && hands.transform.childCount == 0)
        {
            // On porte l'objet

            gameObject.transform.SetParent(hands.transform, false);
            gameObject.transform.position = hands.transform.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (playerInput.CanInteract && hands.transform.childCount > 0)
        {
            // On arrete de porter l'objet

            gameObject.transform.SetParent(null);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}