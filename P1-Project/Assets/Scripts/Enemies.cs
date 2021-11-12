using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Enemy variables
    float speed = 1;
    Vector3 pos;
    Rigidbody rb;


    //Player variables

   [SerializeField]
    GameObject playerObject;
    Player player;
   // Vector3 playerPos;
    
   // Start is called before the first frame update
    void Start()
    {
        //Gets a reference to the Rigidbody
        rb = GetComponent<Rigidbody>();
        //Gets a reference to the player script
        player = playerObject.GetComponent<Player>();
    }

    /// <summary>
    /// Sets the movement to a random direction, and uses MoveEnemy to move
    /// </summary>
    public void RandomMovement()
    {
        {
            Vector3 RandomDirection;
            RandomDirection = new Vector3(Random.Range(-1f, 1f), 0 , (Random.Range(-1f, 1f)));
            MoveEnemy(RandomDirection);
        }
      
    }

    public void MoveEnemy(Vector3 MoveDirection)
    {
        rb.AddForce(MoveDirection * Time.deltaTime * speed, ForceMode.VelocityChange);
        
    }

    /// <summary>
    /// Follows the player if the Distance to the object is smaller than followdistance
    /// </summary>
    public void PlayerFollow()
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        float distance = Vector3.Distance(rb.position, playerRb.position);
        float followdistance = 3f;
        if(distance > followdistance)
        {
            RandomMovement();
        } else
        {
            // Vector3 offset = new Vector3 (player);

            //rb.AddForce(playerRb.position * Time.deltaTime * speed, ForceMode.VelocityChange);
            rb.position = Vector3.MoveTowards(rb.position, playerRb.position, speed * Time.deltaTime);
            transform.LookAt(playerRb.transform);
                
        }
    }

    private void Update()
    {
        PlayerFollow();
    }
}
