using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

[TrackBindingType(typeof(UIDocument))]
[TrackClipType(typeof(DialogueClip))]
public class DialogueTrack : TrackAsset
{

    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<DialogueTrackMixer>.Create(graph, inputCount);
    }


}
