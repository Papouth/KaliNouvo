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

    #endregion


    #region Built In Methods

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if(dollyToTrack == null) Debug.LogError("PAS DE DOLLY NULL REFF");
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

    #endregion


    #region CustomsMethods

    private void ChangeDolly()
    {
        Debug.Log("Cinemachine tracked dolly : " + cB.ActiveVirtualCamera.VirtualCameraGameObject);
        CinemachineVirtualCamera vC = cB.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        vC.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path  = dollyToTrack;   
    }

    #endregion
}
