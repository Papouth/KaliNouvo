using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepo : Npc
{
    private bool isInRange;
    private bool canLook;

    private GameObject playerPos;

    public override void Start()
    {
        base.Start();
        playerPos = GameManager.GM.player;
        canLook = ChanceToLook();
    }

    public override void Update()
    {
        base.Update();
        LookPlayer();
    }

    public override void OnAnimatorIK(int layerIndex)
    {
        base.OnAnimatorIK(layerIndex);
    }


    public override void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
        base.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Peut �tre remplacer par un point d'interrogation par exemple
            //topCube.SetActive(false);

            isInRange = false;
        }

        base.OnTriggerExit(other);
    }

    /// <summary>
    /// Le pepo regarde le joueurs?
    /// </summary>
    private void LookPlayer()
    {
        if (isInRange && canLook && !canMove)
        {
            Vector3 dir = playerPos.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, rotation.y, 0f), Time.deltaTime);
        }
    }

    public bool ChanceToLook()
    {
        int i = 0;
        PlayerStats stats = playerPos.GetComponent<PlayerStats>();
        if (stats.haveTempo)
            i++;
        if (stats.haveTelekinesy)
            i++;
        if (stats.haveSuperForce)
            i++;

        int j = 0;
        j = Random.Range(0, 3 - i);

        if (j == 0)
        {
            return true;
        }
        return false;

    }
}
