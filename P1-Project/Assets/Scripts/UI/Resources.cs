using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public TextMeshProUGUI textCounter;

    public TextMeshProUGUI isReachedText;

    public TextMeshProUGUI ObjectiveText;

    public void SetTrashCollectedText(int trash)
    {
         textCounter.SetText("Dumpsites cleaned: " + trash.ToString() + "/10");

    }

    public void SetIsReachedText(string reachedText)
    {
        isReachedText.SetText(reachedText);
    }

    public void SetObjectiveText(string objectiveText)
    {
        ObjectiveText.SetText(objectiveText);
    }
}
