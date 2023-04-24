using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : CustomsTriggers
{
    #region Variables
    //public GameObject cube;
    //public Transform spawnPos;
    //public GameObject topCube;

    public Dialogue dialogues;
    private DialogueManager manager;
    private Transform player;

    private Animator animator;
    private bool lookPlayer;
    public Transform dummyPivot;
    private float lookWeight;
    [SerializeField] private Vector3 offsetLook;

    [SerializeField] private bool canMove;

    [Header("MovePart")]
    private Transform target;
    private int waypointsIndex = 0;

    private bool stopMove;

    private NavMeshAgent agent;
    [SerializeField]
    private WayPoint wayPoints;


    #endregion


    #region Built In Methods
    public override void Start()
    {
        if (DialogueManager.InstanceDialogue)
            manager = DialogueManager.InstanceDialogue;
        else Debug.LogError("Pas de dialogue manager ?");

        //topCube.SetActive(false);

        if (PlayerInteractor.playerInteractorInstance.GetComponent<PlayerInteractorDistance>() != null)
            playerInteractorDistance = PlayerInteractor.playerInteractorInstance.GetComponent<PlayerInteractorDistance>();

        player = GameManager.GM.cB.ActiveVirtualCamera.LookAt;

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (canMove)
        {
            target = GetWayPointRandom();
        }
    }

    public void Update()
    {
        if (canMove) MoveNpc();
    }


    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
        {
            // Peut �tre remplacer par un point d'interrogation par exemple
            //topCube.SetActive(true);

            lookPlayer = true;

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Peut �tre remplacer par un point d'interrogation par exemple
            //topCube.SetActive(false);


            lookPlayer = false;
            manager.EndDialogue();
            GameManager.GM.canTP = false;
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (LookPlayerIK())
        {
            lookWeight = Mathf.Lerp(lookWeight, 1, Time.deltaTime);
            animator.SetLookAtWeight(lookWeight);

        }
        else
        {
            lookWeight = Mathf.Lerp(lookWeight, 0, Time.deltaTime);
            animator.SetLookAtWeight(lookWeight);
        }

        Vector3 pos = new Vector3(player.position.x + offsetLook.x, player.position.y + offsetLook.y, player.position.z + offsetLook.z);
        animator.SetLookAtPosition(pos);
    }

    #endregion

    #region CustomsMethods

    public override void Interact()
    {
        base.Interact();

        manager.StartDialogue(dialogues);
        GameManager.GM.canTP = true;

        return;
    }

    public override void TextInfo()
    {
        //base.TextInfo();
    }

    /// <summary>
    /// Autorise l'ik à se déclancher
    /// </summary>
    /// <returns></returns>
    private bool LookPlayerIK()
    {
        if (lookPlayer)
        {
            dummyPivot.transform.LookAt(player.position);
            float pivotRotY = dummyPivot.transform.localRotation.y;

            if (pivotRotY < .55f && pivotRotY > -.55f)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }


    /// <summary>
    /// Pour les npcs qui se déplacent
    /// </summary>
    private void MoveNpc()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 1f)
        {
            if (stopMove == false)
            {
                animator.SetFloat("Move", 0);
                stopMove = true;
            }
        }
        else
        {
            animator.SetFloat("Move", agent.velocity.normalized.magnitude);
            agent.SetDestination(target.position);
        }
    }

    public void CanMove()
    {
        if (canMove)
            target = GetWayPointRandom();
    }

    /// <summary>
    /// Set a random anim for the npc
    /// </summary>
    public void IdleNpc()
    {
        int random = Random.Range(0, animator.GetInteger("ReadIndexRandom"));
        animator.SetInteger("IndexRandom", random);
        animator.SetTrigger("PlayRandom");
    }

    /// <summary>
    /// Get a random waypoint
    /// </summary>
    /// <returns></returns>
    public Transform GetWayPointRandom()
    {
        stopMove = false;
        return target = wayPoints.points[Random.Range(0, wayPoints.points.Length)];
    }
    #endregion
}