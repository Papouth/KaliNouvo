using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomlyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponentInChildren<Animator>();
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));
    }
}
