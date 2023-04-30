using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class TriggerCutScene : TriggerInScene
{
    #region Variables

    public PlayableDirector playable;
    private bool isAlreadyPlayed;

    public bool transitionCamera = true;
    private CinemachineBlenderSettings settings;

    #endregion


    #region Built In Methods

    public override void Update()
    {
    }


    #endregion


    #region Customs Methods

    public override void EventOnTriggerEnter()
    {
        if (isAlreadyPlayed) return;

        if (!transitionCamera)
        {
            settings = GameManager.GM.cB.m_CustomBlends;
            GameManager.GM.cB.m_CustomBlends = null;
        }

        playable.Play();
        GameManager.GM.player.GetComponent<CharacterController>().enabled = false;
        isAlreadyPlayed = true;
    }

    public override void EventOnTriggerExit()
    {

    }

    private void OnDisable()
    {
        StopPlayable();
    }

    public void StopPlayable()
    {
        if (!transitionCamera)
        {
            GameManager.GM.cB.m_CustomBlends = settings;
        }

        playable.Stop();
        GameManager.GM.player.GetComponent<CharacterController>().enabled = true;
        playable.gameObject.SetActive(false);
    }

    #endregion
}