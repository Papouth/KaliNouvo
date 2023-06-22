using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class OutroScript : MonoBehaviour
{
    public PlayableDirector firstOption;
    public PlayableDirector secondOption;

    public UIDocument uiDoc;


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
        firstOption.Play();
    }

    /// <summary>
    /// Play the second cut scene
    /// </summary>
    public void PlayerSecondOption()
    {
        secondOption.Play();
    }
}

