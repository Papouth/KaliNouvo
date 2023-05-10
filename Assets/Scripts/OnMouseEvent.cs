using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Ce script sert majoritairement pour la telekinesy
/// </summary>
public class OnMouseEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    #region Variables
    [Header("Telekinesy Parameters")]
    private Renderer objectRend;

    [Tooltip("Matériau affiché au passage de la souris")]
    [SerializeField] private Material mouseOverMat;

    [Tooltip("Matériau affiché après sélection")]
    [SerializeField] private Material selectedMat;
    private Material storedMat;

    private PlayerTelekinesie playerTelekinesie;
    #endregion


    private void Awake()
    {
        playerTelekinesie = GameManager.GM.player.GetComponent<PlayerTelekinesie>();
        objectRend = GetComponent<Renderer>();
        storedMat = objectRend.material;
    }

    private void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerTelekinesie.selected == false)
            objectRend.material = mouseOverMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectRend.material = storedMat;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerTelekinesie.telekinesyOn)
        {
            playerTelekinesie.selected = true;

            playerTelekinesie.telekinesyObject = gameObject;
            playerTelekinesie.rigidbodyObject = gameObject.GetComponent<Rigidbody>();
            playerTelekinesie.colObject = gameObject.GetComponent<Collider>();

            objectRend.material = selectedMat;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerTelekinesie.telekinesyOn)
        {
            playerTelekinesie.selected = false;

            playerTelekinesie.telekinesyObject = null;
            playerTelekinesie.rigidbodyObject = null;

            playerTelekinesie.colObject.enabled = true;
            playerTelekinesie.colObject = null;

            objectRend.material = selectedMat;

        }
    }
}