using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TutorielTrigger : MonoBehaviour
{
    private MenuManager menuManager;
    private PlayerInput playerInput;

    public string startText;

    public KeyCode pressButton;

    public string endText;

    private void Awake()
    {
        menuManager = MenuManager.Instance;
        playerInput = GameManager.GM.playerInput;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            DisplayTutoriel(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            DisplayTutoriel(false);
        }
    }

    private void DisplayTutoriel(bool display)
    {
        
        menuManager.tutoText.text = startText + " " + pressButton.ToString() + " " + endText;

        if (display)
            menuManager.tutoText.style.display = DisplayStyle.Flex;
        else
            menuManager.tutoText.style.display = DisplayStyle.None;
    }

    private void OnDrawGizmos()
    {
        BoxCollider col = GetComponent<BoxCollider>();

        if (col == null) return;

        Gizmos.color = new Color(0, 1, 0, .5f);
        Gizmos.DrawCube(transform.position + col.center, col.size);
    }

}
