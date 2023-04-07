using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : CustomsTriggers
{
    #region Variable

    [HideInInspector] public bool valid;

    [SerializeField] private MeshRenderer _indicator;
    [SerializeField] private Material _indicatorMaterial;

    private Animator _animator;

    #endregion

    #region Built in methods
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    #endregion

    #region Customs Methods

    public override void Interact()
    {
        valid = true;
        Debug.Log("Here");

        if (!_indicator) return;

        _indicator.materials = new Material[2] { _indicator.materials[1], _indicatorMaterial };

        _animator.SetBool("Enable", valid);

    }

    #endregion
}