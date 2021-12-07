using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    //Text for showing the required amount to complete an objective
    public TextMeshProUGUI textCounter;

    //Text for showing the text when a quest is complete
    public TextMeshProUGUI isReachedText;

    //Text for showing the quest objective
    public TextMeshProUGUI ObjectiveText;

    //The amount of trash in the scene
    public int trashInScene
    {
        get { return trashList.Count; }

    }

    List<GameObject> trashList = new List<GameObject>();

    private void Awake()
    {
        trashList.AddRange(GameObject.FindGameObjectsWithTag("Trash"));
        Debug.Log(trashList.Count);

    }

    /// <summary>
    /// Sets the amount of trash collected to the current amount
    /// </summary>
    /// <param name="trash"> the amount of trash collected</param>
    public void SetTrashCollectedText(int trash)
    {
         textCounter.SetText("Dumpsites cleaned: " + trash.ToString() + "/" + trashInScene);

    }
    /// <summary>
    /// Sets the text you want to display when the objective is reached
    /// </summary>
    /// <param name="reachedText"> The text to be displayed</param>
    public void SetIsReachedText(string reachedText)
    {
        isReachedText.SetText(reachedText);
    }

    /// <summary>
    /// Sets the objective text
    /// </summary>
    /// <param name="objectiveText">The text to be displayed</param>
    public void SetObjectiveText(string objectiveText)
    {
        ObjectiveText.SetText(objectiveText);
    }
}
