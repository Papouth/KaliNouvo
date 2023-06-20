using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    protected Animator anim;


    public virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OpenDoor()
    {
        anim.SetTrigger("TrFinalDoor");
    }
}