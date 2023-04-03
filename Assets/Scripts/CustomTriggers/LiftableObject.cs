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
    
    
    public void GoToHand(GameObject hands, PlayerInputManager playerInput)
    {
        //Debug.Log("gotohand");

        if (playerInput.CanInteract && hands.transform.childCount == 0)
        {
            gameObject.transform.SetParent(hands.transform, false);
            gameObject.transform.position = hands.transform.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (playerInput.CanInteract && hands.transform.childCount > 0)
        {
            gameObject.transform.SetParent(null);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}