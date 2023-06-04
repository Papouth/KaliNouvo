using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDeFleur : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Graine"))
        {
            other.transform.localPosition = gameObject.transform.position;
        }
    }
}