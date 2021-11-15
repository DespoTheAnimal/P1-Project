using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public TextMeshPro trashCollected;


    public void setTrashCollected(int trash)
    {
        trashCollected.SetText(trash.ToString());
    }

}
