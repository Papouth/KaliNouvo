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
        if (gameObject.CompareTag("Destroyable") && !haveBeenDestroyed)
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
    public void BreakObject()
    {
        if (playerInput.CanDestroy && playerStats.haveSuperForce && isDestroyable && !haveBeenDestroyed)
        {
            Debug.Log("BreakObject");

            haveBeenDestroyed = true;

            StartCoroutine(DestroyObject());
        }
    }

    public IEnumerator DestroyObject()
    {
        // Animation du joueur
        anim.SetTrigger("TrDestroy");


        yield return new WaitForSeconds(.9583f);

        baseMesh.SetActive(false);
        foreach (var debri in debrisMesh)
        {
            debri.SetActive(true);
            debri.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 5), ForceMode.Impulse);
            Destroy(debri.gameObject, Random.Range(5f, 8f));
        }

        playerInput.CanDestroy = false;
    }
    #endregion
}