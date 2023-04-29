using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Prime : Npc
{
    public GameObject cutSceneToPlay;

    public override void Interact()
    {
        if (GameManager.GM.havePass)
        {
            cutSceneToPlay.SetActive(true);
        }
    }
}
