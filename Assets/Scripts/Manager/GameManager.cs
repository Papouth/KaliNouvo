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
    public bool canTP;

    public CinemachineBrain cB;

    public CinemachineSmoothPath _currentPath;

    public GameObject player;
    public PlayerInput playerInput;

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
}

[System.Serializable]
public class InputRebind
{
    public InputActionReference actionReference;
    public string nameAction;


}