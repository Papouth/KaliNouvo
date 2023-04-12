using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : TriggerInScene
{
    public string scenesToLoad;
    public string scenesToUnload;


    public override void EventOnTriggerEnter()
    {
        Scene scene = SceneManager.GetSceneByName(scenesToLoad);

        if (!scene.isLoaded)
        {
            SceneManager.LoadScene(scenesToLoad, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(scenesToUnload);
        }
    }
}