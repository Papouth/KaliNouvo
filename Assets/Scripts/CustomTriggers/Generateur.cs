using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generateur : CustomsTriggers
{
    #region Variable

    [HideInInspector] public bool valid;

    [Header("Indicateurs")]
    [SerializeField] private Indicateur _indicator;


    [Tooltip("On coche la case si ce generateur active l'indicateur HUB [ZONE HUB]")]
    [SerializeField] private bool indicateurHub;
    [Tooltip("On coche la case si ce generateur active l'indicateur 1 [ZONE 1]")]
    [SerializeField] private bool indicateur1;
    [Tooltip("On coche la case si ce generateur active l'indicateur 2 [ZONE 1]")]
    [SerializeField] private bool indicateur2;
    [Tooltip("On coche la case si ce generateur active l'indicateur 3 [ZONE 2]")]
    [SerializeField] private bool indicateur3;


    private Animator _animator;

    [Header("Barrieres Electriques")]
    [Tooltip("false si pas de barrière qui s'active \n true si une barrière s'active")]
    [SerializeField] private bool activateBarriere;
    [Tooltip("false si pas de barrière qui se désactive \n true si une barrière se désactive")]
    [SerializeField] private bool deactivateBarriere;

    [Tooltip("Les barrières à activer")]
    [SerializeField] private Barriere[] barrieresActivation;
    [Tooltip("Les barrières à désactiver")]
    [SerializeField] private Barriere[] barrieresDeactivation;
    [Tooltip("A cocher si le generateur doit activer toutes les barrieres de la Zone 1")]
    [SerializeField] private bool allBarrieresZ1;

    public UnityEvent eventsOnActivate;

    #endregion

    #region Built in methods
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Start()
    {
        if (GameManager.GM.indicatorG1)
        {
            _animator.SetBool("Enable", true);
        }
        if (GameManager.GM.indicatorG2)
        {
            _animator.SetBool("Enable", true);
        }
        if (GameManager.GM.indicatorG3)
        {
            _animator.SetBool("Enable", true);
        }
        if (GameManager.GM.indicatorHUB)
        {
            _animator.SetBool("Enable", true);
        }
    }

    #endregion

    #region Customs Methods
    public override void Interact()
    {
        base.Interact();
        valid = true;
        Debug.Log("J'active le générateur");

        if (_indicator) _indicator.ChangeMaterial(); 

        if (indicateur1) GameManager.GM.indicatorG1 = true;
        if (indicateur2) GameManager.GM.indicatorG2 = true;
        if (indicateur3) GameManager.GM.indicatorG3 = true;
        if (indicateurHub) GameManager.GM.indicatorHUB = true;

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

        if (allBarrieresZ1)
        {
            GameManager.GM.oneForAll = true;
        }

        eventsOnActivate?.Invoke();
    }
    #endregion
}