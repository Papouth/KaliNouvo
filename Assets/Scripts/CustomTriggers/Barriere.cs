using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriere : MonoBehaviour
{
    [HideInInspector] public bool isActive;
    [SerializeField] private GameObject electricArc;


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