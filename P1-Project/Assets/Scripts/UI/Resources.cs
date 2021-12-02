using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public TextMeshProUGUI textCounter;


    public void SetTrashCollectedText(int trash)
    {
         textCounter.SetText("Dumpsites cleaned: " + trash.ToString() + "/10");

    }
}
