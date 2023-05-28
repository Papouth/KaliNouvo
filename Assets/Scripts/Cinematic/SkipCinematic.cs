using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class SkipCinematic : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    public UnityEvent action;


    /// <summary>
    /// Skip a cinematic
    /// </summary>
    /// <param name="time"></param>
    public void Play(float time)
    {
        action?.Invoke();

        playableDirector.time = time;
    }

}
