using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBaseBehavior : MonoBehaviour
{
    [SerializeField]
    QuestObjectives questObjective;
    Scene curScene;
    int curSceneIndex;

    private void Start()
    {
        curScene = SceneManager.GetActiveScene();
        curSceneIndex = curScene.buildIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questObjective.isReached())
            {
                SceneManager.LoadScene(curSceneIndex++);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questObjective.isReached())
            {
                SceneManager.LoadScene(curSceneIndex++);
            }
        }
    }
}
