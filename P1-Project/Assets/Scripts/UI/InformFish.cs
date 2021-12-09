using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformFish : MonoBehaviour
{
    public Dialogue dialogue;

    public bool beingInformed = false;

    private void Update()
    {
        BeginDialog();
    }

    void BeginDialog()
    {
        if (beingInformed)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
