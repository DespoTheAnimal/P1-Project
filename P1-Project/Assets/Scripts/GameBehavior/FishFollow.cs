using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFollow : Swim
{
    public bool stuckInTrash = true;
    public bool safeFromDanger = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbTarget = GameObject.Find("Player").GetComponent<Rigidbody>();
        speed = 20f;
    }

    private void Update()
    {
        Move();
    }
    /// <summary>
    /// If the Player gameObject it close, it follows it
    /// </summary>
    protected override void MoveByPlayer()
    {

        rb.position = Vector3.MoveTowards(rb.position, rbTarget.position, speed * Time.deltaTime);
        transform.LookAt(rbTarget.position);

    }

    protected override void Move()
    {

        if (safeFromDanger == false && stuckInTrash == false)
        {
            float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
            float followDistance = 35f;
            if (distanceToTarget < followDistance)
            {
                MoveByPlayer();
            }
        }
    }
}