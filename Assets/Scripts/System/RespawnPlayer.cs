using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : RespawnSystem
{
    private CharacterController cc;
    private PlayerMovement player;


    #region Customs Methods
    public override void Start()
    {
        base.Start();
        cc = GetComponent<CharacterController>();
        player = GetComponent<PlayerMovement>();
    }

    public override void Update()
    {
        base.Update();
    }

    public override bool CheckGrounded()
    {
        if (base.CheckGrounded() && player.inCrouch == false) return true;
        else return false;
    }

    /// <summary>
    /// Cree le respawn des objets au dernier points connu et à jour
    /// </summary>
    public override void Respawn()
    {
        Debug.Log("Respawn Player");

        StartCoroutine(RespawnAnim());
    }

    public IEnumerator RespawnAnim()
    {
        cc.enabled = false;
        gameObject.transform.position = respawnPoint.transform.position;

        yield return new WaitForEndOfFrame();

        float i = 0;
        Blit instance = GameManager.GM.fonduNoirMat;

        while (i < 1.3f)
        {
            float currentFloat = instance.settings.blitMaterial.GetFloat("_Transition");
            currentFloat = Mathf.Lerp(currentFloat, 1.3f, i);
            instance.settings.blitMaterial.SetFloat("_Transition", currentFloat);

            i = i + Time.deltaTime * 3f;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        float j = 1.3f;

        while (j > 0)
        {
            float currentFloat = instance.settings.blitMaterial.GetFloat("_Transition");
            currentFloat = Mathf.Lerp(-0.1f, currentFloat, j);

            Debug.Log(currentFloat);
            instance.settings.blitMaterial.SetFloat("_Transition", currentFloat);

            j = j - Time.deltaTime * 3f;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        instance.settings.blitMaterial.SetFloat("_Transition", -.1f);

        cc.enabled = true;
    }

    #endregion
}