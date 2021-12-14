using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueTrigger : MonoBehaviour
{
    //inspired by Brackys: https://www.youtube.com/watch?v=_nRzoTzeyxU
    public Dialogue dialogue;
    private void Start() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
