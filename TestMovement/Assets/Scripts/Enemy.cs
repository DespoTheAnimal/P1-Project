using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    int dmg;
    // Start is called before the first frame update
    void Start()
    {
        dmg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hit(int health)
    {
        health = health - dmg;
    }

}
