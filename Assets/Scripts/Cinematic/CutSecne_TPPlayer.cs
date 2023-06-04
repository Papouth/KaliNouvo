using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutSecne_TPPlayer : MonoBehaviour
{
    private PlayerTemporel playerTemp;
    private PlayerStats playerStats;
    private GameObject kali3D;
    private CharacterController cc;

    public string newSceneToLoad = "Tutoriel_01_Passe";
    public string oldSceneToUnload = "Tutoriel_01_Present";
    public Transform newPosKali;


    void Start()
    {
        playerTemp = GameManager.GM.player.GetComponent<PlayerTemporel>();
        playerStats = GameManager.GM.player.GetComponent<PlayerStats>();
        kali3D = playerTemp.gameObject.transform.GetChild(0).gameObject;
        cc = GameManager.GM.player.GetComponent<CharacterController>();
    }

    public void EnabledKali(bool enabled)
    {
        cc.transform.position = newPosKali.position;
        GameManager.GM.EnableKali(enabled);
    }

    public void ChangePlayerInCutScene()
    {
        playerTemp.ChangeSceneToLoad(newSceneToLoad, oldSceneToUnload);
        playerTemp.LoadingScene();
        playerStats.GetBraceletTempo();

        // Reset des scènes à changer
        playerTemp.ChangeSceneToLoad(oldSceneToUnload, newSceneToLoad);
    }

    /// <summary>
    /// Load the hub
    /// </summary>
    public void LoadHubScene()
    {
        playerTemp.ChangeSceneToLoad(newSceneToLoad, oldSceneToUnload);

        playerStats.transform.position = newPosKali.position;

        SceneManager.UnloadSceneAsync("Tutoriel_01_Passe");
        SceneManager.UnloadSceneAsync("Tutoriel_01_Present");
        Debug.Log("Allo ?");
        SceneManager.LoadScene(oldSceneToUnload, LoadSceneMode.Additive);
        SceneManager.LoadScene(newSceneToLoad, LoadSceneMode.Additive);


    }

    public void ActivateNeedMaskPlayer()
    {
        playerStats.needMask = true;
        playerTemp.ChangeMask();
    }
    
    public void ActivateMask()
    {
        playerStats.ActivateMask();
    }
}
