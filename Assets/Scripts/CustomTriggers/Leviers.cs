using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Leviers : CustomsTriggers
{
    public UnityEvent leverEvent;
    private bool boolCheck;

    [SerializeField] private CinemachineVirtualCamera cameraDoor;
    private bool isFinish;
    [SerializeField] private float timingTransition = 8;
    private float timer;
    private bool animCam;

    public override void Start()
    {
        cameraDoor.Priority = -100;
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