using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFollow : MonoBehaviour
{
    //references
    Rigidbody rb;
    Rigidbody playerRb;

    bool safeFromDanger = false;
    //the speed of the gameobject
    float speed = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToPlayer();
    }
    /// <summary>
    /// If the Player gameObject it close, it follows it
    /// </summary>
    void MoveToPlayer()
    {
        if (safeFromDanger == false)
        {
            float distanceToTarget = Vector3.Distance(rb.position, playerRb.position);
            float followDistance = 10f;
            if (distanceToTarget < followDistance)
            {
                rb.position = Vector3.MoveTowards(rb.position, playerRb.position, speed * Time.deltaTime);
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HomeBase"))
        {
            safeFromDanger = true;

        }
    }
}
