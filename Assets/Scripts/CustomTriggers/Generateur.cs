using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : CustomsTriggers
{
    #region Variable

    [HideInInspector] public bool valid;

    [SerializeField] private MeshRenderer _indicator;
    [SerializeField] private Material _indicatorMaterial;


    #endregion

    #region Built in methods
    private void Start()
    {

    }

    #endregion

    #region Customs Methods

    public override void Interact()
    {
        valid = true;
        Debug.Log("Here");

        if (!_indicator) return;

        _indicator.materials = new Material[2] { _indicator.materials[1], _indicatorMaterial };

    }

    #endregion
}