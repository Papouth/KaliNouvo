using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SkipManager : MonoBehaviour
{
    public SkipScene[] skipScene;



    public void Update()
    {
        foreach (SkipScene skip in skipScene)
        {
            if (Input.GetKeyDown(skip.keycode))
            {
                SkipToScene(skip);
            }
        }
    }

    public void SkipToScene(SkipScene skipScene)
    {
        GameManager.GM.EnableKali(false);

        skipScene.eventOnSkip?.Invoke();

        PlayerTemporel playerTempo = GameManager.GM.player.GetComponent<PlayerTemporel>();



        SceneManager.UnloadSceneAsync("Anim_Intro 1");


        playerTempo.ChangeStringName(skipScene.passeScene, skipScene.presentScene);


        SceneManager.LoadScene(playerTempo.present, LoadSceneMode.Additive);

        SceneManager.LoadScene(playerTempo.past, LoadSceneMode.Additive);

        if (skipScene.isPresent)
        {
            playerTempo.ChangeSceneToLoad(skipScene.presentScene, skipScene.passeScene);
        }
        else
            playerTempo.ChangeSceneToLoad(skipScene.passeScene, skipScene.presentScene);

        playerTempo.LoadingScene();

        playerTempo.transform.position = skipScene.posPlayer.position;

        GameManager.GM.EnableKali(true);
    }


}

[System.Serializable]
public class SkipScene
{
    public string passeScene;
    public string presentScene;

    public KeyCode keycode;

    public UnityEvent eventOnSkip;

    public Transform posPlayer;

    public bool isPresent;

}
