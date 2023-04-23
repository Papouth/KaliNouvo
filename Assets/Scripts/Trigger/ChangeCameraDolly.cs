using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
public class ChangeCameraDolly : TriggerInScene
{
    #region Variable
    public CinemachineSmoothPath dollyToTrack;
    private CinemachineBrain cB;

    private CinemachineSmoothPath _oldTrack;

    #endregion


    #region Built In Methods

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public override void Awake()
    {
        if (dollyToTrack == null) Debug.LogError("PAS DE DOLLY NULL REFF");
    }

    // Start is called before the first frame update
    public override void Start()
    {
        cB = GameManager.GM.cB;
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            //BackToNormalDolly();
        }
    }

    #endregion


    #region CustomsMethods

    /// <summary>
    /// Change the dolly of the cinemachine brain virtual camera to a new dolly
    /// </summary>
    public override void EventOnTriggerEnter()
    {
        Debug.Log("Cinemachine tracked dolly : " + cB.ActiveVirtualCamera.VirtualCameraGameObject);
        CinemachineTrackedDolly currentPath = cB.
            ActiveVirtualCamera.
            VirtualCameraGameObject.
            GetComponent<CinemachineVirtualCamera>().
            GetCinemachineComponent<CinemachineTrackedDolly>();

        if (currentPath.m_Path)
        {

            _oldTrack = (CinemachineSmoothPath)currentPath.m_Path;

            currentPath.m_Path = dollyToTrack;
            GameManager.GM._currentPath = (CinemachineSmoothPath)currentPath.m_Path;

            float pathLenght = dollyToTrack.FindClosestPoint(cB.ActiveVirtualCamera.LookAt.position, 0, -1, 1);
            currentPath.m_PathPosition = pathLenght;
        }

    }

    /// <summary>
    /// Change the dolly of the cinemachine brain virtual camera to the old dolly of the trigger
    /// </summary>
    private void BackToNormalDolly()
    {
        Debug.Log("Cinemachine tracked dolly : " + cB.ActiveVirtualCamera.VirtualCameraGameObject);
        CinemachineVirtualCamera vC = cB.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        vC.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = _oldTrack;
    }

    #endregion
}