using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentances;
    public Text dialogueText;
    public Animator anim;

    private void Start()
    {
        sentances = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isOpen", true);

        sentances.Clear();

        foreach (string sentance in dialogue.sentances)
        {
            sentances.Enqueue(sentance);
        }

        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if(sentances.Count == 0)
        {
            EndDialogue();
            PlayerPrefs.SetInt("Score", 0);
            SceneManager.LoadScene("Game");
            return;
        }

        string sentance = sentances.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentance(sentance));
    }

    IEnumerator TypeSentance(string sentance)
    {
        dialogueText.text = "";
        foreach (char letter in sentance.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueText.text = "Continue the story.";
        anim.SetBool("isOpen", false);
    }

}
