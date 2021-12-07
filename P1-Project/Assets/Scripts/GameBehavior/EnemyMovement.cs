using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    Rigidbody rbTarget;
    Player player;
    readonly float speed = 14f;


    RaycastHit Hit;

    Rigidbody rb;

    int dmg = 2;

    void Start()
    {
        target = GameObject.Find("Player");
        rbTarget = target.GetComponent<Rigidbody>();
        player = target.GetComponent<Player>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();

    }

    /// <summary>
    /// Changes the position towards the player position
    /// </summary>
    void MoveToPlayer()
    {
        rb.position = Vector3.MoveTowards(rb.position, rbTarget.position, speed * Time.deltaTime);
        transform.LookAt(rbTarget.position);
    }

    /// <summary>
    /// Moves forewards
    /// </summary>
    void DefaultMove()
    {
        rb.MovePosition(rb.position + transform.forward * Time.deltaTime * speed);
    }

    /// <summary>
    /// Moves the enemy to an object in the forrward direction, if it gets close to the object the direction changes
    /// </summary>
   // void MoveToObject()
    //{
      //  if (Vector3.Distance(rb.position, Hit.transform.position) > 1f){
      //      rb.position = Vector3.MoveTowards(rb.position, Hit.transform.position, speed * Time.deltaTime);
      //      transform.LookAt(Hit.transform.position);
      //  } else { 
      //      rb.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
      //  } 
    //}

    /// <summary>
    /// if the enemy is close to the player it moves towards the player, 
    /// if the enemy "sees" an object it moves towards it 
    /// else it moves foreward until it finds an object or player
    /// </summary>
    void Move()
    {
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float FollowDistance = 40f;
        if (distanceToTarget < FollowDistance)
        {
            MoveToPlayer();
            
        } else if (Physics.Raycast(rb.position, transform.forward, out Hit, 2f)) {
            //MoveToObject();
            rb.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        } 
        else {
            DefaultMove();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
        } else if (other.gameObject.CompareTag("SafeZone"))
        {
            rb.transform.Rotate(new Vector3(0, Random.Range(0,360),0));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(dmg);
        }
    }
}
