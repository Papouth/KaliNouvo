using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Variables
    [Header("SuperForce")]
    public bool haveSuperForce;
    private PlayerPush playerPush;
    private PlayerSuperForce playerSuperForce;

    public GameObject[] superForceObject;
    public GameObject gantelSuperForce;

    [Header("Bracelet Tempo")]
    public bool haveTempo;

    public GameObject braceletScreen;
    public GameObject braceletTempo;

    
    //Partie Masque
    public GameObject masqueObject;
    public Transform masqueRig;
    public Transform posOffMask;
    public Transform posOnMask;
    private Transform posToLerp;

    private float timerChangeMaskLerp;
    

    public bool needMask;
    public bool changeMask;


    [Header("Telekinesy")]
    public bool haveTelekinesy;
    public GameObject telekinesyObject;

    #endregion


    private void Awake()
    {
        playerPush = GetComponent<PlayerPush>();
        playerSuperForce = GetComponent<PlayerSuperForce>();

        playerSuperForce.enabled = false;

        braceletScreen?.SetActive(false);

        braceletTempo?.SetActive(false);

        telekinesyObject?.SetActive(false);

        //masqueObject?.SetActive(false);

        if (superForceObject.Length != 0)
        {
            foreach (GameObject t in superForceObject)
            {
                t.SetActive(false);
            }
        }

        gantelSuperForce?.SetActive(false);
    }

    private void Start()
    {
        //ChangeMaskPos(false);
    }

    private void Update()
    {
        /*
        if (changeMask)
        {
            ChangeMaskLerp();
        }*/
    }

    public void GetSuperForce()
    {
        //Debug.Log("SuperForce r�cup�r�");
        playerPush.enabled = false;
        playerSuperForce.enabled = true;
        haveSuperForce = true;

        if (superForceObject.Length != 0)
        {
            foreach (GameObject t in superForceObject)
            {
                t.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Active les bracelets de super force
    /// </summary>
    /// <param name="state"></param>
    public void ActivateSuperForceObject(bool state)
    {
        gantelSuperForce?.SetActive(true);
    }

    public void GetBraceletTempo()
    {
        //Debug.Log("Bracelet Tempo r�cup�r�");
        haveTempo = true;

        braceletScreen?.SetActive(true);

        braceletTempo?.SetActive(true);
    }

    public void GetTelekinesy()
    {
        Debug.Log("Telekinesy r�cup�r�");
        haveTelekinesy = true;

        telekinesyObject?.SetActive(true);
    }

    public void ActivateMask()
    {
        masqueObject?.SetActive(true);
    }

    /// <summary>
    /// Change the mask when tp
    /// </summary>
    /// <param name="tp">if true, take the mask, if false leave the mask</param>
    public void ChangeMaskPos(bool tp)
    {
        if (tp) posToLerp = posOnMask;
        else posToLerp = posOffMask;

        changeMask = true;
    }

    /// <summary>
    /// Lerp l'emplacement de changement de masque
    /// </summary>
    private void ChangeMaskLerp()
    {
        if (!posToLerp) return;

        timerChangeMaskLerp = timerChangeMaskLerp + Time.deltaTime;

        Vector3 posMask = Vector3.Lerp(masqueObject.transform.position, posToLerp.position, timerChangeMaskLerp);

        masqueObject.transform.position = posMask;

        if (timerChangeMaskLerp > 1)
        {
            timerChangeMaskLerp = 0;
            changeMask = false;
        }
    }
}