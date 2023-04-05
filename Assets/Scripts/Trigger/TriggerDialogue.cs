using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : TriggerInScene
{
    public Dialogue dialogues;




    public override void EventOnTriggerEnter()
    {
        DialogueManager.InstanceDialogue.StartDialogue(dialogues);
    }
}
