using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    public void Interact();

    public List<Material> GetMaterialGameObject();
}

public abstract class CustomsTriggers : MonoBehaviour, IInteractable
{
    protected float weight;
    protected Rigidbody rb;

    [HideInInspector] public PlayerInteractorDistance playerInteractorDistance;


    public virtual void Start()
    {
        PlayerInteractor player = PlayerInteractor.playerInteractorInstance;
        Debug.Log(player);
        playerInteractorDistance = player.gameObject.GetComponent<PlayerInteractorDistance>();

        rb = GetComponent<Rigidbody>();

        if (rb == null) return;

        weight = rb.mass;
    }

    public virtual void Interact()
    {
        Debug.Log("fesse");
        return;
    }

    public virtual List<Material> GetMaterialGameObject()
    {
        MeshRenderer[] objects = GetComponentsInChildren<MeshRenderer>();

        List<Material> mats = new List<Material>();

        foreach(MeshRenderer mesh in objects)
        {
            foreach(Material mat in mesh.materials)
            {
                mats.Add(mat);
            }
        }

        return mats;
    }

    public virtual void TextInfo()
    {
        // Debug.Log(interactText);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextInfo();
        }
    }

    /// <summary>
    /// Called when is visible by a camera
    /// Override if we don't want them to be in the interaction
    /// </summary>
    public virtual void OnBecameVisible()
    {
        if (playerInteractorDistance != null)
            playerInteractorDistance.AddList(this); 
    }

    /// <summary>
    /// Called when is invisble  by a camera
    /// Override if we don't want them to be in the interaction
    /// </summary>
    public virtual void OnBecameInvisible()
    {
        if (playerInteractorDistance != null)
            playerInteractorDistance.RemoveList(this);
    }
}