using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformFish : MonoBehaviour
{
    public Dialogue dialogue;

    public bool beingInformed = false;
    int time = 0;

    private void Update()
    {
        Debug.Log(beingInformed);
        Debug.Log(time);
        BeginDialog();
    }

    void BeginDialog()
    {
       
        if (beingInformed && time == 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            time++;
        }
    }
}
