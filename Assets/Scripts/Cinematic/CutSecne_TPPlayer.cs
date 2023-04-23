using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        cc.enabled = enabled;
        kali3D.SetActive(enabled);
    }

    public void ChangePlayerInCutScene()
    {
        playerTemp.ChangeSceneToLoad(newSceneToLoad, oldSceneToUnload);
        playerTemp.LoadingScene();
        playerStats.GetBraceletTempo();

        // Reset des scènes à changer
        playerTemp.ChangeSceneToLoad(oldSceneToUnload, newSceneToLoad);
    }
}