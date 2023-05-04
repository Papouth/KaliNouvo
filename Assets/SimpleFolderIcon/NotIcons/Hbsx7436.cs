using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Hbsx7436 : CustomsTriggers
{
    [SerializeField] private GameObject theProp;
    private MeshRenderer rendProp;
    [SerializeField] private Material theMat;
    [SerializeField] private Material hbsxMat;
    private bool hbOn;

    private void Awake()
    {
        rendProp = theProp.GetComponent<MeshRenderer>();
    }

    public override void Interact()
    {
        if (!hbOn) Exec();
        else if (hbOn) Unexec();

        return;
    }

    private void Exec()
    {
        rendProp.material = hbsxMat;
        hbOn = true;
    }

    private void Unexec()
    {
        rendProp.material = theMat;
        hbOn = false;
    }
}