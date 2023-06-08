using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Ce script permet au joueur d'empêcher de se tp quand il rentre dans la zone
/// </summary>
public class AntiTP : TriggerCutScene
{

    public override void EventOnTriggerEnter()
    {
        GameManager.GM.canTP = true;
    }

    public override void EventOnTriggerExit()
    {
        GameManager.GM.canTP = false;
    }
}