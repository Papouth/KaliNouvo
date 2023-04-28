using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : CustomsTriggers
{
    private bool isDestroyable;
    [Header("GameObjet A Detruire")]
    [SerializeField] private GameObject baseMesh;
    [SerializeField] private GameObject[] debrisMesh;
    private bool haveBeenDestroyed;

    [Header("Player Component")]
    private PlayerInputManager playerInput;
    private PlayerStats playerStats;
    private Animator anim;



    public override void Start()
    {
        if (gameObject.CompareTag("Destroyable"))
        {
            isDestroyable = true;

            foreach (var debri in debrisMesh)
            {
                debri.SetActive(false);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BreakObject();
        }
    }

    /// <summary
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput = other.GetComponent<PlayerInputManager>();
            playerStats = other.GetComponent<PlayerStats>();
            anim = other.GetComponent<Animator>();
        }
    }

    #region Destroy Objects
    public bool BreakObject()
    {
        if (playerInput.CanDestroy && playerStats.haveSuperForce && isDestroyable && !playerInput.CanTelekinesy && !haveBeenDestroyed)
        {
            Debug.Log("here");

            haveBeenDestroyed = true;

            // Animation du joueur
            anim.SetTrigger("TrDestroy");

            baseMesh.SetActive(false);
            foreach (var debri in debrisMesh)
            {
                debri.SetActive(true);
                debri.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            }

            playerInput.CanDestroy = false;

            return true;
        }

        return false;
    }
    #endregion
}