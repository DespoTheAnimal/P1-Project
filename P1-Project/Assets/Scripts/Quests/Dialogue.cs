using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//inspired by Brackys: https://www.youtube.com/watch?v=_nRzoTzeyxU
[System.Serializable]
public class Dialogue
{
    public string title;

    [TextArea(3, 10)]
    public string[] sentences;
   
}