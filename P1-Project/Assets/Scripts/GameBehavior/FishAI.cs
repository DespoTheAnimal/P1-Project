using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inspiration from https://answers.unity.com/questions/1380771/random-spawn-gameobject-in-area.html

public class FishAI : Swim
{

    // Start is called before the first frame update
    void Start()
    {
        rbTarget = GameObject.Find("Player").GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        setSpeed();
    }

    void setSpeed()
    {
        speed = (Random.Range(10, 20));

    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected override void MoveByPlayer()
    {
        transform.LookAt(rbTarget.transform);
    }

    protected override void Move()
    {
        if (CastRay(2f))
        {
            if (Hit.transform.gameObject.CompareTag("Player"))
            {
                MoveByPlayer();
            }
            RotateDirection();
        } else
        {
            DefaultMove();
        }
    }
}