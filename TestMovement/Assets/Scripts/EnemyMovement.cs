using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    Rigidbody rbTarget;

    float speed = 3;

    RaycastHit Hit;

    Rigidbody rb;


    void Start()
    {
        target = GameObject.Find("Player");
        rbTarget = target.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    /// <summary>
    /// Changes the position towards the player position
    /// </summary>
    void MoveToPlayer()
    {
        rb.position = Vector3.MoveTowards(rb.position, rbTarget.transform.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// Moves forewards
    /// </summary>
    void DefaultMove()
    {
        rb.MovePosition(rb.position + (transform.forward) * Time.deltaTime * 16 * speed);
    }

    /// <summary>
    /// Moves the enemy to an object in the forrward direction, if it gets close to the object the direction changes
    /// </summary>
    void MoveToObject()
    {
        rb.position = Vector3.MoveTowards(rb.position, Hit.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(rb.position, Hit.transform.position) < 1f)
        {
            transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        }
    }

    /// <summary>
    /// if the enemy is close to the player it moves towards the player, 
    /// if the enemy is "sees" an object it moves towards it 
    /// else it moves foreward until it finds an object or player
    /// </summary>
    void Move()
    {
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float FollowDistance = 7f;
        if (distanceToTarget < FollowDistance)
        {
            MoveToPlayer();
            
        } else if (Physics.Raycast(rb.position, transform.forward, out Hit, 20f)) {
            MoveToObject();
        }
        else {
            DefaultMove();
        }

    }

}
