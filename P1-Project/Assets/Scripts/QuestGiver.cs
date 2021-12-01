using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quests quest;

    public Player player;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    private void start()
    {
        OpenQuestWindow();
    }

    // this function will open the quest window when the corresponding button is clicked in the game. The displayed information is referenced by the inputs made through the "Quests" class
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
    }

    // this function will allow the player to accept the displayed quest
    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        
        // need a script here to give the player the quest (make a list in Player for multiple quests)
    }



}
