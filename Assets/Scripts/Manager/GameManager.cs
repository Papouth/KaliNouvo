using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager GM;
    public bool havePass;
    [Tooltip("Si faux : le joueur peut voyager dans le temps \n Si vrai : le joueur ne peut plus voyager dans le temps")]
    public bool canTP;

    public CinemachineBrain cB;

    public CinemachineSmoothPath _currentPath;

    public GameObject player;
    public PlayerInput playerInput;
    public Transform lookPlayer;

    public InputRebind[] actionMap;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    #endregion

    #region Built In Methods
    private void Awake()
    {
        if (GM != null)
        {
            GameObject.Destroy(GM);
        }
        else
        {
            GM = this;
        }

        DontDestroyOnLoad(this);

        playerInput = player.GetComponent<PlayerInput>();
    }

    #endregion

    /// <summary>
    /// Start the rebinding methods when player click on the text field
    /// </summary>
    /// <param name="index"></param>
    /// <param name="textField"></param>
    public void StartRebinding(int index, TextField textField)
    {
        actionMap[index].actionReference.action.Disable();

        rebindingOperation = actionMap[index].actionReference.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(index, textField))
            .Start();
    }

    /// <summary>
    /// When rebind is complete
    /// </summary>
    /// <param name="index"></param>
    /// <param name="textField"></param>
    public void RebindComplete(int index, TextField textField)
    {
        rebindingOperation.Dispose();

        textField.SetValueWithoutNotify(InputControlPath.ToHumanReadableString(
                actionMap[index].actionReference.action.bindings[0]
                .effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice));

        textField.Blur();

        actionMap[index].actionReference.action.Enable();
    }


    //Louis garde ca secret stp

    private string[] cheatCode;
    private int index;
    [SerializeField] private RuntimeAnimatorController _animNpc;

    private List<RuntimeAnimatorController> animatorsNPC = new List<RuntimeAnimatorController>();
    private RuntimeAnimatorController playerAnimator;

    void Start()
    {
        // Code is "z,z,s,s,q,d,q,d,a,b", user needs to input this in the right order
        cheatCode = new string[] { "z", "z", "s", "s", "q", "d", "q", "d", "b", "a" };
        index = 0;
    }

    void Update()
    {
        InputCheatCodeSecret();
    }

    void InputCheatCodeSecret()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length)
        {
            // Cheat code successfully inputted!
            // Unlock crazy cheat code stuff
            CheatCode();
        }
    }

    void CheatCode()
    {
        index = 00;
        ReplaceAnimator();
    }

    private void ReplaceAnimator()
    {
        Npc[] npcs = FindObjectsOfType<Npc>();

        foreach (Npc npc in npcs)
        {
            if (npc.GetComponent<Animator>().runtimeAnimatorController != null)
                animatorsNPC.Add(npc.GetComponent<Animator>().runtimeAnimatorController);
            npc.GetComponent<Animator>().runtimeAnimatorController = _animNpc;
        }

        playerAnimator = player.GetComponentInChildren<Animator>().runtimeAnimatorController;
        player.GetComponentInChildren<Animator>().runtimeAnimatorController = _animNpc;

        StartCoroutine(DisableCheat());
    }

    private void BackToNormal()
    {
        Npc[] npcs = FindObjectsOfType<Npc>();

        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].GetComponent<Animator>().runtimeAnimatorController = animatorsNPC[i];
        }

        player.GetComponentInChildren<Animator>().runtimeAnimatorController = playerAnimator;
    }

    private IEnumerator DisableCheat()
    {
        yield return new WaitForSecondsRealtime(30f);
        BackToNormal();
    }
}

[System.Serializable]
public class InputRebind
{
    public InputActionReference actionReference;
    public string nameAction;
}