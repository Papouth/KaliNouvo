using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviateurSocle : MonoBehaviour
{
    [Header("Barriere Associated")]
    [SerializeField] private Barriere barriereToDeactivate;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deviateur"))
        {
            other.transform.localPosition = gameObject.transform.position;
            barriereToDeactivate.deviated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deviateur"))
        {
            barriereToDeactivate.deviated = false;
        }
    }
}