using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

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

    public UnityEvent events;

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

        GameManager.GM.player.GetComponent<PlayerMovement>().cc.enabled = false;


        if (Vector3.Distance(Camera.main.transform.position, target) <= .1f)
        {
            doorAnimator.SetBool("IsValid", true);
        }

        timer += Time.deltaTime;

        if (timer >= timingTransition)
        {
            cameraDoor.Priority = -100;
            isFinish = true;
            GameManager.GM.player.GetComponent<PlayerMovement>().cc.enabled = true;

            if (events.GetPersistentEventCount() > 0)
                events.Invoke();
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
                    canUnlock = false;
                    return;
                }
            }
        }
        else { canUnlock = false; return; }

        canUnlock = true;
    }

    public void UnlockDoorLever()
    {
        canUnlock = true;
    }



    #endregion
}