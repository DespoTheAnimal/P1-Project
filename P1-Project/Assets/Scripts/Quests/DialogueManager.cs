using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    [SerializeField]
    private float waitTime;


    void Awake()
    {
        sentences = new Queue<string>();
    }

    private void Start()
    {
        StartCoroutine(WaitBeforeShow(waitTime));
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        
        titleText.text = dialogue.title;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    private IEnumerator WaitBeforeShow(float time)
    {     
        while (enabled)
        {
            yield return new WaitForSeconds(time);
            DisplayNextSentence();
        }
    }
}
