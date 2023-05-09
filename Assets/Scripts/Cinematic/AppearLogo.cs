using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppearLogo : MonoBehaviour
{
    private UIDocument uidoc;
    private VisualElement logo;
    public float displayDuration;

    public bool isEnable;

    // Start is called before the first frame update
    void Start()
    {
        uidoc = GetComponent<UIDocument>();
        logo = uidoc.rootVisualElement.Q<VisualElement>("Logo");
        logo.style.opacity = 0;
    }

    private void Update()
    {
        if (isEnable == false)
        {
            StartCoroutine(EnableLogo());

        }
    }

    private IEnumerator EnableLogo()
    {
        Debug.Log("Here 1");
        isEnable = true;

        logo.style.opacity = 1;

        yield return new WaitForSecondsRealtime(displayDuration);

        logo.style.opacity = 0;

        Debug.Log("Here 2");
    }

}
