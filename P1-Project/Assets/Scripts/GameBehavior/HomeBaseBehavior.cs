using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBaseBehavior : MonoBehaviour
{
    //Reference to the objective
    [SerializeField]
    QuestObjectives questObjective;

    //scene variables
    Scene curScene;
    int curSceneIndex;

    private void Start()
    {
        //Reference to the active scene
        curScene = SceneManager.GetActiveScene();
        //gets the build index of the active scene
        curSceneIndex = curScene.buildIndex;
    }
    /// <summary>
    /// Checks for colliders entering trigger
    /// </summary>
    /// <param name="other">the collider of the other gameobject</param>
    private void OnTriggerEnter(Collider other)
    {
        //if the collider is a player the scene changes to the next in the build list
        if (other.CompareTag("Player"))
        {
            if (questObjective.isReached())
            {
                SceneChange.LoadNextScene(curSceneIndex);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questObjective.isReached())
            {
                SceneChange.LoadNextScene(curSceneIndex);
            }
        }
        if (other.CompareTag("SafeFish"))
        {
            other.GetComponent<FishFollow>().safeFromDanger = true;
        }
    }
}
