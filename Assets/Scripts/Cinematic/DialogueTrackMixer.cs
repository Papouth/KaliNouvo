using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class DialogueTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        UIDocument uidoc = playerData as UIDocument;

        if (!uidoc) return;
        if (uidoc.gameObject.activeSelf == false) return;

        if (uidoc.rootVisualElement == null) return;
        if (uidoc.rootVisualElement.Q<Label>("TutoText") == null) return;

        Label label = uidoc.rootVisualElement.Q<Label>("TutoText");

        if (label == null) return;

        string currentText = "";
        float currentAlpha = 0f;

        if (label == null) return;

        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            if (inputWeight > 0f)
            {
                ScriptPlayable<DialogueBehaviour> inputPlayable = (ScriptPlayable<DialogueBehaviour>)playable.GetInput(i);

                DialogueBehaviour input = inputPlayable.GetBehaviour();

                currentText = input.dialogue.nameOfPeople + " : " + input.dialogue.sentences[0];
                currentAlpha = inputWeight;
            }
        }

        label.text = currentText;
        label.style.opacity = currentAlpha;





        /*if (DialogueManager.InstanceDialogue)
        {
            DialogueManager.InstanceDialogue.EndDialogue();


            int inputCount = playable.GetInputCount();

            for(int i = 0; i <inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);

                if (inputWeight > 0f)
                {
                    ScriptPlayable<DialogueBehaviour> inputPlayable = (ScriptPlayable<DialogueBehaviour>)playable.GetInput(i);

                    DialogueBehaviour input = inputPlayable.GetBehaviour();

                    DialogueManager.InstanceDialogue.StartDialogue(input.dialogue);
                }
            }
        }*/
    }
}
