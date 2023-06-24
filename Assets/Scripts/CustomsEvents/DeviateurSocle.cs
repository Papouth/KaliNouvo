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
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().useGravity = false;


            other.transform.position = transform.position;
            barriereToDeactivate.deviated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deviateur"))
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().useGravity = true;


            barriereToDeactivate.deviated = false;
        }
    }
}