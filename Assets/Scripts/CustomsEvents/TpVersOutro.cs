using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TpVersOutro : MonoBehaviour
{
    #region Variables
    [Header("TP Attributes")]
    [Tooltip("Les temporalit�s de la sc�ne dans laquelle on va se tp")]
    [SerializeField] private string outroPast;
    [SerializeField] private string outroPresent;
    [Tooltip("L'endroit o� kali va se tp")]
    [SerializeField] private Transform tp;

    [Header("Player Components")]
    private PlayerTemporel playerTempo;
    private CharacterController cc;

    [Header("Black Screen")]
    public float durationRenderFeature;
    [Tooltip("Set 0 pour empecher le mat�riaux de revenir")]
    public float speedFeatureMat = 1;
    public Blit renderFeatureMat;
    public string nameParameterFeature;
    #endregion


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTempo = other.GetComponent<PlayerTemporel>();
            cc = other.GetComponent<CharacterController>();

            // On emp�che le joueur de se TP dans une autre tempo
            GameManager.GM.canTP = true;

            // On d�sactive le character controller
            cc.enabled = false;

            // Fondu en noir
            StartCoroutine(SetBlackScreen());
        }
    }

    private void LoadTempo()
    {
        // On d�charge les sc�nes de la zone
        SceneManager.UnloadSceneAsync(playerTempo.past);
        SceneManager.UnloadSceneAsync(playerTempo.present);

        // On change les sc�nes pass� et pr�sent du joueur
        playerTempo.ChangeStringName(outroPast, outroPresent);
        playerTempo.ChangeSceneToLoad(outroPast, outroPresent);

        // On load les sc�nes pass� et pr�sent de la nouvelle zone
        SceneManager.LoadScene(playerTempo.past, LoadSceneMode.Additive);
        SceneManager.LoadScene(playerTempo.present, LoadSceneMode.Additive);
    }

    public IEnumerator SetBlackScreen()
    {
        float i = 0;

        while (i < 1.3f)
        {
            float currentFloat = renderFeatureMat.settings.blitMaterial.GetFloat(nameParameterFeature);
            currentFloat = Mathf.Lerp(currentFloat, 1.3f, i);
            renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, currentFloat);

            i = i + Time.deltaTime / speedFeatureMat;

            yield return new WaitForSeconds(Time.deltaTime / speedFeatureMat);
        }

        if (durationRenderFeature == 0) StopAllCoroutines();

        LoadTempo();

        yield return new WaitForSeconds(durationRenderFeature);

        // ne passe pas car disable
        float j = 1.3f;

        while (j > 0)
        {
            float currentFloat = renderFeatureMat.settings.blitMaterial.GetFloat(nameParameterFeature);
            currentFloat = Mathf.Lerp(-0.1f, currentFloat, j);

            renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, currentFloat);

            j = j - Time.deltaTime / speedFeatureMat;

            yield return new WaitForSeconds(Time.deltaTime / speedFeatureMat);
        }


        renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, -.1f);
    }

    private void OnDisable()
    {
        // Reset des sc�nes pour le joueur
        playerTempo.ChangeSceneToLoad(outroPresent, outroPast);

        // On met Kali a la bonne position
        cc.transform.position = tp.position;

        // On r�active le character controller
        cc.enabled = true;

        // On remet la possibilit� au joueur de se TP dans une autre tempo
        GameManager.GM.canTP = false;


        renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, -.1f);
    }
}