using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInScene : MonoBehaviour
{
    #region Variables

    public Color colorGizmo;

    #endregion

    public virtual void Awake()
    {

    }

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            EventOnTriggerEnter();
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3) //Player
        {
            EventOnTriggerExit();
        }
    }

    /// <summary>
    /// methods when player enter the triggers
    /// </summary>
    public virtual void EventOnTriggerEnter()
    {

    }

    /// <summary>
    /// Methods when player exit the triggers
    /// </summary>
    public virtual void EventOnTriggerExit()
    {

    }


    public virtual void OnDrawGizmos()
    {
        BoxCollider col = GetComponent<BoxCollider>();

        if (col == null) return;

        Gizmos.color = colorGizmo;

        Gizmos.DrawCube(transform.position + col.center, col.size);
    }
}
