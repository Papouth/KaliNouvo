using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generateur : CustomsTriggers
{
    #region Variable

    [HideInInspector] public bool valid;

    [SerializeField] private MeshRenderer _indicator;
    [SerializeField] private Material _indicatorMaterial;

    private Animator _animator;

    [Header("Barrieres Electriques")]
    [Tooltip("false si pas de barri�re qui s'active \n true si une barri�re s'active")]
    [SerializeField] private bool activateBarriere;
    [Tooltip("false si pas de barri�re qui se d�sactive \n true si une barri�re se d�sactive")]
    [SerializeField] private bool deactivateBarriere;

    [Tooltip("Les barri�res � activer")]
    [SerializeField] private Barriere[] barrieresActivation;
    [Tooltip("Les barri�res � d�sactiver")]
    [SerializeField] private Barriere[] barrieresDeactivation;

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
        Debug.Log("J'active le g�n�rateur");

        if (!_indicator) return;

        _indicator.materials = new Material[2] { _indicator.materials[1], _indicatorMaterial };

        _animator.SetBool("Enable", valid);


        if (activateBarriere)
        {
            if (barrieresActivation.Length == 0)
            {
                Debug.Log("ERREUR PAS DE BARRIERE DE RENSEIGNER");
                return;
            }

            foreach (var bar in barrieresActivation)
            {
                bar.Activation();
            }
        }

        if (deactivateBarriere)
        {
            if (barrieresDeactivation.Length == 0)
            {
                Debug.Log("ERREUR PAS DE BARRIERE DE RENSEIGNER");
                return;
            }

            foreach (var bar in barrieresDeactivation)
            {
                bar.Desactivate();
            }
        }
    }
    #endregion
}