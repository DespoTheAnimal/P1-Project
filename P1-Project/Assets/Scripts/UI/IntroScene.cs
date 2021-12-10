using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Intro");
        FindObjectOfType<AudioManager>().Play("UnderWater");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
