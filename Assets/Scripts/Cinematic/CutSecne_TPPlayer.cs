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
    public string newPast;
    public string newPresent;
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

        playerTemp.sceneState = !playerTemp.sceneState;
        playerStats.maskOn = !playerStats.maskOn;
        StartCoroutine(playerTemp.ChangeMaskEnumerator());

        playerStats.GetBraceletTempo();

        // Reset des scènes à changer
        playerTemp.ChangeSceneToLoad(oldSceneToUnload, newSceneToLoad);
    }

    public void ChangeStringNameCutScene()
    {
        playerTemp.ChangeStringName(newPast, newPresent);
    }

    /// <summary>
    /// Load the hub
    /// </summary>
    public void LoadHubScene()
    {
        playerTemp.ChangeSceneToLoad(newSceneToLoad, oldSceneToUnload);
        playerTemp.ChangeStringName(oldSceneToUnload, newSceneToLoad);

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
        playerStats.masqueObject.SetActive(true);
        playerStats.StartCoroutine(MaskCoroutine());
    }
    public IEnumerator MaskCoroutine()
    {
        playerTemp.ChangeMask();

        yield return new WaitForSeconds(playerTemp.timingAnimMask);

        playerTemp.animator.SetLayerWeight(1, 0);
    }

    public void ActivateMask()
    {
        playerStats.ActivateMask();
    }

    public void GetSuperForceCutScene()
    {
        playerStats.GetSuperForce();
    }

    public void GetTelekinesieCutScene()
    {
        playerStats.GetTelekinesy();
    }

    public void ChangeMusic(int index)
    {
        MusicManager.Instance.ChangeMusic(index);
    }
}
