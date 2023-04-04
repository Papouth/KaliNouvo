using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TutorielTrigger : TriggerInScene
{
    private MenuManager menuManager;
    private PlayerInput playerInput;

    public string startText;

    public InputActionReference actionReference;

    public string endText;

    public override void Awake()
    {
        menuManager = MenuManager.Instance;
        playerInput = GameManager.GM.playerInput;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            DisplayTutoriel(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            DisplayTutoriel(false);
        }
    }

    private void DisplayTutoriel(bool display)
    {
        string textToDisplay;

        textToDisplay = startText + " " + InputControlPath.ToHumanReadableString(
                actionReference.action.bindings[0]
                .effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        if (textToDisplay.Contains(startText + " " + "2DVector"))
        {
            textToDisplay = startText + " " + "Z,Q,S,D";
        }


        menuManager.tutoText.text = textToDisplay + " " + endText;

        if (display)
            menuManager.tutoText.style.display = DisplayStyle.Flex;
        else
            menuManager.tutoText.style.display = DisplayStyle.None;
    }
}
