using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    // References to the player
    GameObject target;
    Rigidbody rbTarget;
    Player player;

    //The speed of the enemy
    readonly float speed = 14f;

    //Variable for containing the RaycastHit information
    RaycastHit Hit;

    //reference to the enemy rigidbody
    Rigidbody rb;

    //How much the shark hurts the player
    int dmg = 2;

    void Start()
    {
        target = GameObject.Find("Player");
        rbTarget = target.GetComponent<Rigidbody>();
        player = target.GetComponent<Player>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// Changes the position towards the player position if it isn't in the safe zone
    /// </summary>
    void MoveToPlayer()
    {
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float distance = 3f;

        if (player.inSafeZone == false )
        {
            rb.position = Vector3.MoveTowards(rb.position, rbTarget.position, speed * Time.deltaTime);
            if (distance < distanceToTarget)
                transform.LookAt(rbTarget.position);
        } else
        {
            DefaultMove();
        }  
    }

    /// <summary>
    /// Moves forewards
    /// </summary>
    void DefaultMove()
    {
        rb.MovePosition(rb.position + transform.forward * Time.deltaTime * speed);
    }


    void Move()
    {
        //if the shark is close to the player it moves towards it
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float FollowDistance = 40f;
        if (distanceToTarget < FollowDistance)
        {
            MoveToPlayer();
        //if the shark gets close to an object it changes direction
        } else if (Physics.Raycast(rb.position, transform.forward, out Hit, 2f)) {

            rb.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        } 
        else {
            DefaultMove();
        }

    }

    //if the enemy touches the player it deals damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
       } 
    }

    //The enemy keeps dealing damage when touching the player
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
        }
    }
}
