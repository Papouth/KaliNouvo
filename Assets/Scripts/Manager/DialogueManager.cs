using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager InstanceDialogue { get; set; }

    private Queue<string> sentences;
    public float speedDisplay;

    public PlayerInputManager playerInput;

    public float timeDisplayDialogue = 3;


    void Awake()
    {
        InstanceDialogue = this;
        sentences = new Queue<string>();
    }


    #region Dialogue

    /// <summary>
    /// Appelle un dialogue
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        if (dialogue.sentences.Length == 0) return;
        MenuManager.Instance.EnableInfoText(true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentece(dialogue);
    }

    /// <summary>
    /// Display the next sentences
    /// </summary>
    /// <param name="dialogue"></param>
    public void DisplayNextSentece(Dialogue dialogue)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();


        StartCoroutine(TypeSentence(sentence, dialogue));
    }

    /// <summary>
    /// Display the letter in the sentences
    /// </summary>
    /// <param name="sentence"></param>
    /// <param name="dialogue"></param>
    /// <returns></returns>
    public IEnumerator TypeSentence(string sentence, Dialogue dialogue)
    {
        string newSentence = dialogue.nameOfPeople + " : " + sentence;


        MenuManager.Instance.MajInfoText(newSentence);

        yield return new WaitForSeconds(.1f);
        yield return WaitForDoneProcess(timeDisplayDialogue);

        DisplayNextSentece(dialogue);
    }


    IEnumerator WaitForDoneProcess(float timeout)
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
            timeout -= Time.deltaTime;
            if (timeout <= 0f) break;
        }
        Debug.Log("Input");
    }

    /// <summary>
    /// End the dialogues
    /// </summary>
    public void EndDialogue()
    {
        if (MenuManager.Instance == null) return;

        sentences.Clear();
        MenuManager.Instance.EnableInfoText(false);
    }
}

#endregion


[System.Serializable]
public class Dialogue
{
    public string nameOfPeople;

    [TextArea(3, 10)]
    public string[] sentences;

}