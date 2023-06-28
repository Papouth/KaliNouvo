using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public bool isGen1Trigger;
    public bool isGen3Trigger;

    public GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        if (isGen1Trigger)
        {
            if(GameManager.GM.player.GetComponent<PlayerStats>().haveSuperForce)
            trigger.SetActive(true);
        }
        if (isGen3Trigger)
        {
            if(GameManager.GM.indicatorG3)
            trigger.SetActive(true);
        }
    }
}
