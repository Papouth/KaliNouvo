using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : CustomsTriggers
{
    private GameManager gameManager;

    public Dialogue dialogueWhenInteract;

    public override void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void Interact()
    {
        gameManager.havePass = true;
        DialogueManager.InstanceDialogue.StartDialogue(dialogueWhenInteract);

        Destroy(gameObject);

        base.Interact();
    }
}