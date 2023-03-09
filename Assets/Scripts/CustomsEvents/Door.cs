using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Door : MonoBehaviour
{
    #region Variable
    public Generateur[] generateur;
    private Animator doorAnimator;
    [SerializeField] private CinemachineVirtualCamera cameraDoor;
    private Vector3 target;
    private bool isFinish;
    private bool canUnlock;
    [SerializeField] private float timingTransition = 8;
    private float timer;

    #endregion

    #region Built In Methods
    private void Awake()
    {
        doorAnimator = GetComponentInChildren<Animator>();

        if (doorAnimator == null) Debug.LogError("PAS DANIMATOR");

        if (cameraDoor == null) Debug.LogError("PAS DE CAMERA DOOR");

        if (generateur.Length == 0) Debug.LogError("PAS DE GENERATEUR");

        target = cameraDoor.transform.position;
    }


    public void Update()
    {
        CanUnlockDoor();

        if (isFinish == false && canUnlock == true)
        {
            UnlockDoor();
        }
    }

    #endregion

    #region Customs Methods

    /// <summary>
    /// Debloque la porte et desactive ces collider, active les vfx, active l'animation
    /// </summary>
    private void UnlockDoor()
    {
        cameraDoor.m_Priority = 100;

        if (Vector3.Distance(Camera.main.transform.position, target) <= .1f)
        {
            doorAnimator.SetBool("IsValid", true);
        }

        timer += Time.deltaTime;

        if (timer >= timingTransition)
        {
            cameraDoor.Priority = -100;
            isFinish = true;
        }
    }

    /// <summary>
    /// Debloque la porte si les generateurs sont actifs
    /// </summary>
    /// <returns></returns>
    private void CanUnlockDoor()
    {
        if (generateur.Length > 0)
        {
            for (int i = 0; i < generateur.Length; i++)
            {
                if (generateur[i].valid == false)
                {
                    Debug.Log("Here1");
                    canUnlock = false;
                    return;
                }
            }
        }
        else { canUnlock = false; Debug.Log("Here2"); return; }

        Debug.Log("Here3");
        canUnlock = true;
    }

    public void UnlockDoorLever()
    {
        canUnlock = true;
    }



    #endregion
}