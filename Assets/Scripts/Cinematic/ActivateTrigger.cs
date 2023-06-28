using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    [Tooltip("Generateur Z1, part1")]
    public bool isGen1Trigger;

    [Tooltip("Generateur Z1 Part 2")]
    public bool isGen2Trigger;

    [Tooltip("Generateur Z2")]
    public bool isGen3Trigger;

    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        if (isGen1Trigger)
        {
            if (GameManager.GM.player.GetComponent<PlayerStats>().haveSuperForce)
            {
                trigger.SetActive(true);
            }
            else
            {
                trigger.SetActive(false);
            }
        }
        if (isGen2Trigger)
        {
            if (GameManager.GM.indicatorG2)
            {
                trigger.SetActive(true);
            }
            else
            {
                trigger.SetActive(false);
            }
        }
        if (isGen3Trigger)
        {
            if (GameManager.GM.indicatorG3)
            {
                trigger.SetActive(true);
            }
            else
            {
                trigger.SetActive(false);
            }
        }
    }
}
