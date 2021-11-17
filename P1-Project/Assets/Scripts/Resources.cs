using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public TextMeshPro trashCollected;


    public void SetTrashCollectedText(int trash)
    {
        trashCollected.SetText(trash.ToString());
    }

}
