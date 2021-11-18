using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public TextMeshPro trashCollected;
    public TextMeshProUGUI textCounter;


    public void SetTrashCollectedText(int trash)
    {
         textCounter.SetText("Trash:" + trash.ToString());

    }
}
