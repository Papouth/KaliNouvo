using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetStat : CustomsTriggers
{
    #region Variables
    public UnityEvent statEvent;
    private bool statState;
    public Animation statAnim;

    private PlayerStats playerStats;
    private bool unlockScript;

    [Tooltip("A cocher si c'est pour avoir le bracelet temporel")]
    [SerializeField] private bool tempoExternPlayer;

    [Tooltip("A cocher si c'est pour avoir la super force")]
    [SerializeField] private bool forceForPlayer;

    [Tooltip("A cocher si c'est pour avoir la telekinesy")]
    [SerializeField] private bool telekinesyForPlayer;

    [Tooltip("La porte à fermer quand on récupère la telekinesy")]
    [SerializeField] private Animator doorAnimator;
    #endregion



    private void Update()
    {
        TempoException();
        ForceException();
        TelekinesyException();
    }

    public override void Interact()
    {
        if (!statState && statEvent != null) statEvent.Invoke();

        return;
    }

    public void AnimSuperForce()
    {
        // On joue l'animation de recuperation de la super force
        statState = true;
        //statAnim.Play();
    }

    public void AnimBraceletTempo()
    {
        // On joue l'animation de recuperation du bracelet de tempo
        statState = true;
        //statAnim.Play();
    }

    public void AnimTelekinesy()
    {
        // On joue l'animation de recuperation de la telekinesy
        statState = true;
        // statAnim.Play();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !unlockScript)
        {
            playerStats = other.GetComponent<PlayerStats>();
            unlockScript = true;
        }
    }

    private void TempoException()
    {
        if (tempoExternPlayer && unlockScript)
        {
            tempoExternPlayer = false;
            statEvent = new UnityEvent();
            statEvent.AddListener(playerStats.GetBraceletTempo);
        }
    }

    private void ForceException()
    {
        if (forceForPlayer && unlockScript)
        {
            forceForPlayer = false;
            statEvent = new UnityEvent();
            statEvent.AddListener(playerStats.GetSuperForce);
            Debug.Log("super force");
        }
    }

    private void TelekinesyException()
    {
        if (telekinesyForPlayer && unlockScript)
        {
            telekinesyForPlayer = false;
            statEvent = new UnityEvent();
            statEvent.AddListener(playerStats.GetTelekinesy);

            // Animation porte qui se referme
            doorAnimator.SetBool("closeDoor", true);

            Debug.Log("Telekinesy Acquise");
        }
    }
}