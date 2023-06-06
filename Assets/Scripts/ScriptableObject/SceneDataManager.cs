using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneDataManager : MonoBehaviour
{
    public SceneData sceneData;

    public TriggerCutScene[] triggerCutScene;

    private void OnEnable()
    {

        for (int i = 0; i < triggerCutScene.Length; i++)
        {
            triggerCutScene[i].index = i;
            triggerCutScene[i].enabled = sceneData.triggersCutSceneIsChecked[i];
        }
    }

    public void Awake()
    {

    }

    public void CheckTrigger(TriggerCutScene trigger)
    {
        if (triggerCutScene.Contains(trigger))
        {
            sceneData.triggersCutSceneIsChecked[trigger.index] = true;
        }
    }
}
