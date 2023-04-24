using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriere : MonoBehaviour
{
    private Collider[] barriereCols;
    public bool isActive;


    private void Awake()
    {
        barriereCols = GetComponents<Collider>();

        foreach (var col in barriereCols)
        {
            col.enabled = false;
        }
    }

    public void Activation()
    {
        if (!isActive)
        {
            isActive = true;

            foreach (var col in barriereCols)
            {
                col.enabled = true;
            }

            // Activation de l'effet s'il y en a un
        }
    }

    public void Desactivate()
    {
        if (isActive)
        {
            isActive = false;

            foreach (var col in barriereCols)
            {
                col.enabled = false;
            }

            // Désactivation de l'effet s'il y en a un
        }
    }
}