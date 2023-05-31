using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicateur : MonoBehaviour
{
    [Header("Indicateurs")]
    [SerializeField] private MeshRenderer _indicator;
    [SerializeField] private Material _indicatorMaterial;

    [Header("Concerne la zone 1 uniquement")]
    [Tooltip("A cocher si est activé par le generateur1 de la zone 1")]
    [SerializeField] private bool gen1;
    [Tooltip("A cocher si est activé par le generateur2 de la zone 1")]
    [SerializeField] private bool gen2;
    [Tooltip("A cocher si est activé par le generateur3 de la zone 2")]
    [SerializeField] private bool gen3;


    private void OnEnable()
    {
        if (gen1 && GameManager.GM.indicatorG1)
        {
            ChangeMaterial();
        }
        if (gen2 && GameManager.GM.indicatorG2)
        {
            ChangeMaterial();
        }
        if (gen3 && GameManager.GM.indicatorG3)
        {
            ChangeMaterial();
        }
    }

    public void ChangeMaterial()
    {
        _indicator.material = new Material(_indicatorMaterial);
    }
}