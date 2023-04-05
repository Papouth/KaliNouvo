using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutScene : TriggerInScene
{
    #region Variables

    public PlayableDirector playable;
    private bool isAlreadyPlayed;

    public Dialogue[] sentencesToPlay;

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
        playable.Pause();
        GameManager.GM.player.GetComponent<CharacterController>().enabled = true;
    }

    public void PlayDialogue(int index)
    {
        DialogueManager.InstanceDialogue.StartDialogue(sentencesToPlay[index]);
    }

    #endregion
}