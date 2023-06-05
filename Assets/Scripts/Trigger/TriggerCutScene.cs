using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.UIElements;

public class TriggerCutScene : TriggerInScene
{
    #region Variables

    public PlayableDirector playable;
    private bool isAlreadyPlayed;

    public bool transitionCamera = true;
    private CinemachineBlenderSettings settings;

    public SceneDataManager sceneDataManager;

    public int index;

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

        isAlreadyPlayed = true;

        sceneDataManager?.CheckTrigger(this);

        GameManager.GM.player.GetComponent<PlayerInteractor>().rootInteraction.style.display = DisplayStyle.None;

    }

    public override void EventOnTriggerExit()
    {
    }


    public void StopPlayable()
    {
        if (!transitionCamera)
        {
            GameManager.GM.cB.m_CustomBlends = settings;
        }

        GameManager.GM.EnableKali(true);

        if (playable)
        {
            playable.gameObject.SetActive(false);
            playable.Stop();
        }

    }

    #endregion
}