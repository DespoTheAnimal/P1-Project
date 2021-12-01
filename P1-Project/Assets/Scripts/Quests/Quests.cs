using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// is used to make sure that the quests can show up in Unity's inspector
[System.Serializable]
public class Quests 
{
    //is used to indicate whether the quest is currently active or not
    public bool isActive;

    // will state the title of the current quest
    public string title;
    // will give a description of the current quest
    public string description;

    public QuestObjectives questObjective;

}
