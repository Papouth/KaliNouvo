using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideRespawn : MonoBehaviour
{
    #region Built In methods
    public Color colorGizmo;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<RespawnSystem>())
        {
            other.GetComponentInChildren<RespawnSystem>().Respawn();
        }
    }



    private void OnDrawGizmos()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        if (box == null) return;

        Gizmos.color = colorGizmo;

        Gizmos.DrawCube(transform.position + box.center, box.size);
    }
    #endregion
}