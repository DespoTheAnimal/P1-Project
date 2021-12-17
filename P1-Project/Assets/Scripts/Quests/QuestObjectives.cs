using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// is used to make sure that the values can be edited in Unity's inspector

public class QuestObjectives : MonoBehaviour
{
    //Reference to the resources
    public Resources resource;

    [SerializeField]
    public objectiveType objectiveType;

    // will indicate the required amount needed to complete the quest
    [SerializeField]
    public int requiredAmount;

    //will indicate how far the player is in terms of completing their quest objective
    [SerializeField]
    public int currentAmount;

    private void Update()
    {
        CleanUpObjective();
        CompleteObjective();
    }

    // this will check whether or not the player has reached the quest objective by seeing if the current amount is greater than or equal to the required amount
    // basically it says if the above is true, then "true" will be returned for the function, otherwise it will return false
    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

    /// <summary>
    /// if the objective is complete, the text on the screen will change
    /// </summary>
    void CompleteObjective()
    {
        if (isReached())
        {
            resource.ObjectiveText.enabled = false;
            resource.textCounter.enabled = false;
            resource.SetIsReachedText("Tag tilbage til din hjemmebase for at klare missionen!");

        }
    }

    /// <summary>
    /// If the objectivetype is cleanUp the objective text will be changed to "Pollution gathering", currentamount will be
    /// how much trash is picked up and the requiredamount is the amount of trash in the scene
    /// </summary>
    void CleanUpObjective()
    {

        switch (objectiveType)
        {
            case objectiveType.cleanUp:
                resource.SetObjectiveText("Find skrald");
                currentAmount = GameObject.Find("Player").GetComponent<Player>().trashPickedUp;
                requiredAmount = resource.objectList[0];
                resource.SetCounterText("Forurening indsamlet: " + currentAmount.ToString() + "/" + requiredAmount);
                break;
            case objectiveType.escort:
                FishFollow boobles = GameObject.FindGameObjectWithTag("SafeFish").GetComponent<FishFollow>();
                if (boobles.stuckInTrash == true)
                {
                    resource.SetObjectiveText("Bobbles sider fast i affald, red ham!");
                } else
                {
                    resource.SetObjectiveText("tag Boobles til din hjemmebase");
                }
                 requiredAmount = 1;
                if (boobles.safeFromDanger == false)
                {
                    currentAmount = 0;
                } else currentAmount = 1;
                break;
            case objectiveType.educate:
                resource.SetObjectiveText("Informer andre om konsekvenser ved affald ");
                currentAmount = GameObject.Find("Player").GetComponent<Player>().fishInformed;
                requiredAmount = resource.objectList[2];
                resource.SetCounterText("Informer: " + currentAmount.ToString() + "/" + requiredAmount);
                break;
            case objectiveType.repair:
                resource.SetObjectiveText("Red korallerne!");
                currentAmount = GameObject.Find("Player").GetComponent<Player>().coralsCleansed;
                requiredAmount = resource.objectList[1];
                resource.SetCounterText("Koraller repareret: " + currentAmount.ToString() + "/" + requiredAmount);
                break;
        } 
    }
}

// this creates the different types of objectives for the quests. E.g. that we have gathering quests and clean-up quests
public enum objectiveType
{
    cleanUp,
    escort,
    repair,
    educate
}
