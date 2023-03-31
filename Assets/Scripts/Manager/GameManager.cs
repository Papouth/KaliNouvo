using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager GM;
    public bool havePass;

    public CinemachineBrain cB;

    public CinemachineSmoothPath _currentPath;

    public GameObject player;
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
    }
    #endregion
}