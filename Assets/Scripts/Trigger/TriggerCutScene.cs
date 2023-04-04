using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutScene : TriggerInScene
{
    #region Variables

    public PlayableDirector playable;


    #endregion


    #region Built In Methods

    public override void Update()
    {
    }


    #endregion


    #region Customs Methods

    public override void EventOnTriggerEnter()
    {
        playable.Play();
    }

    public override void EventOnTriggerExit()
    {

    }

    #endregion
}
