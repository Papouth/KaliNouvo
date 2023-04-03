using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartCam : MonoBehaviour
{
    #region Variable
    public CinemachineSmoothPath dollyToTrack;
    private CinemachineVirtualCamera vc;

    #endregion


    private void Start()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        vc.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = dollyToTrack;
    }
}