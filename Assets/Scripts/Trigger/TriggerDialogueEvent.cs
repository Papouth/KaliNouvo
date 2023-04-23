using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDialogueEvent : TriggerDialogue
{
    public UnityEvent eventOnEnterTrigger;
    public UnityEvent eventOnExitTrigger;


    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (eventOnEnterTrigger != null)
            eventOnEnterTrigger.Invoke();
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (eventOnExitTrigger != null)
            eventOnExitTrigger.Invoke();
    }
}
