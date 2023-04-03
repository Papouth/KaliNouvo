using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager GM;
    public bool havePass;

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


    public void StartRebinding(int index, TextField textField)
    {
        textField.value = "Input";

        rebindingOperation = actionMap[index].actionReference.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(textField));
    }

    public void RebindComplete(TextField textField)
    {
        rebindingOperation.Dispose();
        textField.value = rebindingOperation.ToString();
    }
}

[System.Serializable]
public class InputRebind
{
    public InputActionReference actionReference;
    public string nameAction;


}