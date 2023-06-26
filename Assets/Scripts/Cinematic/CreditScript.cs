using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public AudioSource audioScene;

    public string mainMenuScene;
    public int waitForLoadScene = 3;

    public void StartEndScene()
    {
        StartCoroutine(EndScene());
    }

    public IEnumerator EndScene()
    {
        float i = audioScene.volume;

        while(i > 0)
        {
            i -= Time.deltaTime / 10;
            audioScene.volume = i;

            yield return new WaitForSeconds(Time.deltaTime / 10);
        }

        yield return new WaitForSeconds(waitForLoadScene);

        SceneManager.LoadScene(mainMenuScene);
    }
}
