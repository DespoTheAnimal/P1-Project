using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiotest : MonoBehaviour
{
    private int timeWaited;
    private int timeDestroy;
    GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        timeWaited = 8;
        timeDestroy = 2;
        StartCoroutine(TimeBeforeSound(timeWaited, timeDestroy));
    }
    IEnumerator TimeBeforeSound(int waitTime, int waitTimeDestroy)
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<AudioManager>().Play("Cartman");
        yield return new WaitForSeconds(waitTimeDestroy);
        Destroy(audioManager, 1);
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
