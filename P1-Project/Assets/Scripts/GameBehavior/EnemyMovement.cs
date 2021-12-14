using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : Swim
{

    //referenceToThePlayer
    Player player;

    //How much the shark hurts the player
    int dmg = 5;
    [SerializeField]
    GameObject dangerSign;

    void Start()
    {
        rbTarget = GameObject.Find("Player").GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
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
    protected override void MoveByPlayer()
    {
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float distance = 3f;
        rb.position = Vector3.MoveTowards(rb.position, rbTarget.position, speed * Time.deltaTime);
        if (distance < distanceToTarget)
             transform.LookAt(rbTarget.position);
    }

    /// <summary>
    /// Moves forwards
    /// </summary>
    protected override void Move()
    {
        //if the shark is close to the player it moves towards it
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float FollowDistance = 80f;
        if (distanceToTarget < FollowDistance)
        {
            dangerSign.SetActive(true);
            if (player.inSafeZone == false)
            {
                MoveByPlayer();
            }
            else DefaultMove();

            //if the shark gets close to an object it changes direction
        } else if (CastRay(2f)) {

            RotateDirection();
        } 
        else {
            DefaultMove();
            dangerSign.SetActive(false);
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
