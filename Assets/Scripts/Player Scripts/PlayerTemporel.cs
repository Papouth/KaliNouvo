using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTemporel : MonoBehaviour
{
    #region Variables
    [Header("Scènes")]
    public string scenesToLoad;
    public string scenesToUnload;
    public string past;
    public string present;
    public bool sceneState;

    public float timingAnimTemp = 0;
    private bool inStateChangeTempo = false;

    [Header("Player Component")]
    private PlayerInputManager playerInput;
    private PlayerInteractor playerInteractor;
    private PlayerStats playerStats;
    private Animator animator;
    private CharacterController cc;

    #endregion

    #region Built In Methods
    private void Awake()
    {
        playerInput = GetComponent<PlayerInputManager>();
        playerInteractor = GetComponent<PlayerInteractor>();
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

        if (past == null || present == null) return;

        //SceneManager.LoadScene(past, LoadSceneMode.Additive);
        //SceneManager.LoadScene(present, LoadSceneMode.Additive);
    }

    private void Start()
    {
        //PastSceneAtStart();

        //scenesToLoad = past;
        //scenesToUnload = present;
    }

    private void Update()
    {
        ChangeTempo();
    }
    #endregion

    public void ChangeStringName(string newPast, string newPresent)
    {
        past = newPast;
        present = newPresent;
    }

    public void PastSceneAtStart()
    {
        Scene pastScene = SceneManager.GetSceneByName(past);

        GameObject[] pastUnload = pastScene.GetRootGameObjects();

        foreach (var item in pastUnload)
        {
            item.SetActive(false);
        }
    }

    public void ChangeSceneToLoad(string newSceneToLoad, string newSceneToUnload)
    {
        scenesToLoad = newSceneToLoad;
        scenesToUnload = newSceneToUnload;
    }

    /// <summary>
    /// Change the scene to load/unload when player hit the input
    /// </summary>
    private void ChangeTempo()
    {
        if (playerInput.ChangeTempo && playerInteractor.hands.transform.childCount == 0 && playerStats.haveTempo && !inStateChangeTempo && !GameManager.GM.canTP)
        {
            StartCoroutine(TimingTempo());
        }
        else if (playerInput.ChangeTempo && !playerStats.haveTempo || inStateChangeTempo || GameManager.GM.canTP) playerInput.ChangeTempo = false;
    }

    private IEnumerator TimingTempo()
    {
        inStateChangeTempo = true;
        cc.enabled = false;
        animator.SetBool("Tempo", true);

        yield return new WaitForSeconds(timingAnimTemp);

        // On change de temporalit�
        LoadingScene();

        sceneState = !sceneState;

        // Une fois changé de tempo on inverse les scènes
        if (sceneState)
        {
            // On est dans le passé
            scenesToLoad = present;
            scenesToUnload = past;
        }
        else if (!sceneState)
        {
            // On est dans le présent
            scenesToLoad = past;
            scenesToUnload = present;
        }

        playerInput.ChangeTempo = false;
        inStateChangeTempo = false;
        cc.enabled = true;
        animator.SetBool("Tempo", false);
    }

    /// <summary>
    /// Loading the scenes 
    /// </summary>
    public void LoadingScene()
    {
        Scene scene = SceneManager.GetSceneByName(scenesToLoad);

        GameObject[] goSceneLoad = scene.GetRootGameObjects();

        goSceneLoad[0].SetActive(true);

        /*foreach (var item in goSceneLoad)
        {
            item.SetActive(true);
        }*/


        Scene unloadScene = SceneManager.GetSceneByName(scenesToUnload);
        GameObject[] goSceneUnload = unloadScene.GetRootGameObjects();
        goSceneUnload[0].SetActive(false);

        /*foreach (var item in goSceneUnload)
        {
            item.SetActive(false);
        }*/

        /*
        if (!scene.isLoaded)
        {
            SceneManager.LoadScene(scenesToLoad, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(scenesToUnload);
        }
        */
    }
}