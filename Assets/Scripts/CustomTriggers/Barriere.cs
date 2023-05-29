using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriere : MonoBehaviour
{
    [HideInInspector] public bool isActive;
    [SerializeField] private GameObject electricArc;
    [Tooltip("Sert à savoir si une barrière est devié \n False = n'est pas devié \n True = barrière devié")]
    [HideInInspector] public bool deviated;


    private void OnEnable()
    {
        if (GameManager.GM)
        {
            if (GameManager.GM.oneForAll && !deviated) electricArc.SetActive(true);
        }
    }

    private void Update()
    {
        Deviated();
    }

    private void Deviated()
    {
        if (deviated) electricArc.SetActive(false);
        else if (!deviated) electricArc.SetActive(true);
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

            // Désactivation de l'effet s'il y en a un
        }
    }
}