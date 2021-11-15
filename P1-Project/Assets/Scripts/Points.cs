using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    
    public TextMeshPro trashPickedUp;


    public void SetTrashPickUp(int trash)
    {
        trashPickedUp.SetText(trash.ToString());
    }
}
