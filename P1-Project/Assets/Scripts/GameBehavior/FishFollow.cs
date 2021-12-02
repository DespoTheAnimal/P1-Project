using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFollow : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody playerRb;
    float speed = 7f;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        float distanceToTarget = Vector3.Distance(rb.position, playerRb.position);
        float followDistance = 10f;
        if (distanceToTarget < followDistance )
        {
            rb.position = Vector3.MoveTowards(rb.position, playerRb.position, speed * Time.deltaTime);
        }
    }

}
