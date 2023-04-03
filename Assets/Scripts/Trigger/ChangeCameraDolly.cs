using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
public class ChangeCameraDolly : MonoBehaviour
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
    private void Awake()
    {
        if (dollyToTrack == null) Debug.LogError("PAS DE DOLLY NULL REFF");
    }

    // Start is called before the first frame update
    void Start()
    {
        cB = GameManager.GM.cB;
    }


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            ChangeDolly();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            //BackToNormalDolly();
        }
    }

    #endregion

    private void OnDrawGizmos()
    {
        BoxCollider col = GetComponent<BoxCollider>();

        if (col == null) return;

        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(transform.position + col.center, col.size);
    }


    #region CustomsMethods

    /// <summary>
    /// Change the dolly of the cinemachine brain virtual camera to a new dolly
    /// </summary>
    private void ChangeDolly()
    {
        Debug.Log("Cinemachine tracked dolly : " + cB.ActiveVirtualCamera.VirtualCameraGameObject);
        CinemachineTrackedDolly currentPath = cB.
            ActiveVirtualCamera.
            VirtualCameraGameObject.
            GetComponent<CinemachineVirtualCamera>().
            GetCinemachineComponent<CinemachineTrackedDolly>();

        _oldTrack = (CinemachineSmoothPath)currentPath.m_Path;

        currentPath.m_Path = dollyToTrack;
        GameManager.GM._currentPath = (CinemachineSmoothPath)currentPath.m_Path;

        float pathLenght = dollyToTrack.FindClosestPoint(cB.ActiveVirtualCamera.LookAt.position, 0, -1, 1);
        currentPath.m_PathPosition = pathLenght;

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