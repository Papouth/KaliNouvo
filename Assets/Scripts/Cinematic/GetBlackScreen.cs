using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class GetBlackScreen : MonoBehaviour
{
    public float durationRenderFeature;

    public float speedFeatureMat = 1;

    public Blit renderFeatureMat;
    public string nameParameterFeature;

    public void StartBlackScreen()
    {
        StartCoroutine(SetBlackScreen());
    }

    public IEnumerator SetBlackScreen()
    {
        float i = 0;

        while (i < 1.3f)
        {
            float currentFloat = renderFeatureMat.settings.blitMaterial.GetFloat(nameParameterFeature);
            currentFloat = Mathf.Lerp(currentFloat, 1.3f, i / speedFeatureMat);
            renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, currentFloat);

            i = i + Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(durationRenderFeature);

        float j = 1.3f;

        while (j > 0)
        {
            float currentFloat = renderFeatureMat.settings.blitMaterial.GetFloat(nameParameterFeature);
            currentFloat = Mathf.Lerp(-0.1f, currentFloat, j / speedFeatureMat);

            renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, currentFloat);

            j = j - Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }


        renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, -.1f);
    }

    private void OnDisable()
    {
        renderFeatureMat.settings.blitMaterial.SetFloat(nameParameterFeature, -.1f);
        StopAllCoroutines();
    }
}
