using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneChange : MonoBehaviour
{

    int curSceneIndex;

    [SerializeField]
    int sceneChangeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(TimeBeforeSceneSwap(sceneChangeTime));
        Debug.Log(curSceneIndex);
    }

    IEnumerator TimeBeforeSceneSwap(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneChange.LoadNextScene(curSceneIndex);
    }
}
