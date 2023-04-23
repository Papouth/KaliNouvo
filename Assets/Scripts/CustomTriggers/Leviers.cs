using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Leviers : CustomsTriggers
{
    public UnityEvent leverEvent;
    private bool boolCheck;

    [Tooltip("Quand on l'active le levier ne marche pas")]
    public bool isBroke;

    [SerializeField] private CinemachineVirtualCamera cameraDoor;
    private bool isFinish;
    [SerializeField] private float timingTransition = 8;
    private float timer;
    private bool animCam;

    private Animator animator;

    public override void Start()
    {
        animator = GetComponent<Animator>();


        if (cameraDoor)
            cameraDoor.Priority = -100;

        if (isBroke)
        {
            animator.Play("Default");

            leverEvent.RemoveAllListeners();
        }

    }

    private void Update()
    {
        if (isFinish == false && animCam)
        {
            CameraAnim();
        }
    }

    public override void Interact()
    {
        if (!boolCheck) leverEvent.Invoke();

        return;
    }

    /// <summary>
    /// Camera Anim
    /// </summary>
    private void CameraAnim()
    {
        cameraDoor.m_Priority = 100;

        GameManager.GM.player.GetComponent<PlayerMovement>().cc.enabled = false;

        timer += Time.deltaTime;

        if (timer >= timingTransition)
        {
            cameraDoor.Priority = -100;
            isFinish = true;
            GameManager.GM.player.GetComponent<PlayerMovement>().cc.enabled = true;
        }
    }

    public void SetCameraAnim()
    {
        animCam = true;
    }
}