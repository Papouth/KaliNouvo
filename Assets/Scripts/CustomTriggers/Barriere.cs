using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriere : MonoBehaviour
{
    [Tooltip("Sert � savoir si la barri�re est active au start")]
    [SerializeField] public bool isActive;
    [SerializeField] private GameObject electricArc;
    [Tooltip("Sert � savoir si une barri�re est devi� \n False = n'est pas devi� \n True = barri�re devi�")]
    [HideInInspector] public bool deviated;

    private void OnEnable()
    {
        // bug ici

        if (GameManager.GM)
        {
            if (GameManager.GM.oneForAll && !deviated && isActive) electricArc.SetActive(true);
        }
    }

    private void Update()
    {
        Deviated();
    }

    private void Deviated()
    {
        if (deviated) electricArc.SetActive(false);
        else if (!deviated && isActive) electricArc.SetActive(true);
    }

    public void Activation()
    {
        if (!isActive)
        {
            isActive = true;

            electricArc.SetActive(true);

            // Activation de l'effet s'il y en a un
        }
    }

    public void Desactivate()
    {
        if (isActive)
        {
            isActive = false;

            electricArc.SetActive(false);

            // D�sactivation de l'effet s'il y en a un
        }
    }
}