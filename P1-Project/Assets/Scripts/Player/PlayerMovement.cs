using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed of the player
    public float speed;
    //The height of the jump
    public float jump;

    //A reference to the rigidbody of the player
    public Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {

    }

    //uwu
    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    /// <summary>
    /// Moves on the x or z axis depending on the key pressed
    /// </summary>
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

    }
    /// <summary>
    /// method to jump if the player stands on the ground
    /// </summary>
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 0.6f))
        {
            rig.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }
}
