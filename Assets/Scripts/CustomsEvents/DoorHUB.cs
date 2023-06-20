using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHUB : FinalDoor
{
    private bool isOpen;

    public override void Start()
    {
        base.Start();
    }

    private void OpenDoor()
    {
        anim.SetTrigger("TrHUBDoor");
    }

    private void Update()
    {
        if (GameManager.GM.indicatorG1 && GameManager.GM.indicatorG2 && GameManager.GM.indicatorG3 && GameManager.GM.indicatorHUB && !isOpen)
        {
            isOpen = true;
            OpenDoor();
        }
    }
}