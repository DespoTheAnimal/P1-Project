using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// is used to make sure that the values can be edited in Unity's inspector
[System.Serializable]
public class QuestObjectives 
{
    public objectiveType objectiveType;

    // will indicate the required amount needed to complete the quest
    public int requiredAmount;

    //will indicate how far the player is in terms of completing their quest objective
    public int currentAmount;

    // this will check whether or not the player has reached the quest objective by seeing if the current amount is greater than or equal to the required amount
    // basically it says if the above is true, then "true" will be returned for the function, otherwise it will return false
    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

}

// this creates the different types of objectives for the quests. E.g. that we have gathering quests and clean-up quests
public enum objectiveType
{
    Gathering,
    cleanUp,
    findItem,
}
