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
        rb = GetComponent<Rigidbody>();
        player = playerObject.GetComponent<Player>();
    }

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
