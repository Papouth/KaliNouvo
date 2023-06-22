using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OutroScript : MonoBehaviour
{
    public PlayableDirector mokslasOption;
    public PlayableDirector gamtasOption;
    public GameObject timelineDebut;

    public UIDocument uiDoc;

    public string creditScene;


    public void Awake()
    {
        uiDoc = GetComponent<UIDocument>();
        SetUpUIDoc();
    }

    public void SetUpUIDoc()
    {
        VisualElement root = uiDoc.rootVisualElement;


        Button firstOption = root.Q<Button>("Mokslas");
        Button secondOption = root.Q<Button>("Gamtas");

        firstOption.clicked += () => { PlayerFirstOption(); };
        secondOption.clicked += () => { PlayerSecondOption(); };
    }

    /// <summary>
    /// Play the first cut scene of the game
    /// </summary>
    public void PlayerFirstOption()
    {
        mokslasOption.Play();
        uiDoc.enabled = false;
        timelineDebut.SetActive(false);
    }

    /// <summary>
    /// Play the second cut scene
    /// </summary>
    public void PlayerSecondOption()
    {
        gamtasOption.Play();
        uiDoc.enabled = false;
        timelineDebut.SetActive(false);
    }

    public void LauchCreditScene()
    {
        SceneManager.LoadScene(creditScene);
    }
}

