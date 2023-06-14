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

    public bool click;
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
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (click == false)
        {
            objectRend.material = storedMat;
        }
        Debug.Log("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerTelekinesie.telekinesyOn)
        {
            Debug.Log("click");
            playerTelekinesie.AddObjectTelekinesie(gameObject);
            objectRend.material = selectedMat;
            click = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerTelekinesie.telekinesyOn)
        {
            Debug.Log("Up");
            playerTelekinesie.RemoveTelekinesieObject();
            objectRend.material = storedMat;

        }
        click = false;
    }
}