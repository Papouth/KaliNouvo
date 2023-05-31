using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerUnityEvent : TriggerInScene
{
    public UnityEvent onTriggerAction;

    public UnityEvent onTriggerRelease;

    /// <summary>
    /// methods when player enter the triggers
    /// </summary>
    public override void EventOnTriggerEnter()
    {
        onTriggerAction?.Invoke();
    }

    /// <summary>
    /// Methods when player exit the triggers
    /// </summary>
    public override void EventOnTriggerExit()
    {
        onTriggerRelease?.Invoke();
    }
}
