using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueClip : PlayableAsset
{
    public Dialogue dialogue;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playbale = ScriptPlayable<DialogueBehaviour>.Create(graph);

        DialogueBehaviour dialogueBehaviour = playbale.GetBehaviour();
        dialogueBehaviour.dialogue = dialogue;

        return playbale;
    }
}
