using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This scriptt was inspired by SouperTrooper's video https://www.youtube.com/watch?v=526OvMqEk_M
public class PlayerMovement1 : MonoBehaviour
{
    public Controls controls;
    public float hoverSpeed = 50f;
    private float activeHoverSpeed;
    private float hoveAcceleration = 2f;
    [SerializeField]
    Vector2 inputs;
    public int swim;
    [SerializeField]
    float rotation;
    Vector3 vel;
    public float baseSpeed = 4f, runSpeed = 8f, rotateSpeed =4f;

    [SerializeField]
    bool run = true;
    public int timer = 0;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPosInputs();
        RotationInputs();
        LocoMotion();
    }
    void LocoMotion()
    {
        Vector2 inputNormalized = inputs;
        //Rotation
        Vector3 rotate =transform.eulerAngles + new Vector3(0,rotation * rotateSpeed,0);
        transform.eulerAngles = rotate;

        float speed = baseSpeed;
        switch (run)
        {
            case true:
                speed = runSpeed;
                if (inputNormalized.y < 0)
                    speed = baseSpeed;
                break;
            case false:
                speed = baseSpeed;
                break;
        }

        //vel depends on the inputs and multiplies by the speed
        vel = (transform.forward * inputNormalized.y + transform.right * inputNormalized.x) * speed;
        rb.velocity = vel;
        //moves the player up or down depending on the keypresses defineded in the "Hover" inputs        
        rb.position += (transform.up * swim * Time.deltaTime);
    }

    void GetPosInputs()
    {
        //Sets the y coordinate of the input (-1 to 1) depending on the key press
        inputs.y = Input.GetAxis("Vertical");
        //Strafe left
        if (Input.GetKey(controls.strafeRight))
        {
            inputs.x = 1;
        }
        //Strafe Right
        if (Input.GetKey(controls.strafeLeft))
        {
            //If both keys are pressed, no strafing
            if (Input.GetKey(controls.strafeRight))
            {
                inputs.x = 0;
            } else
                inputs.x = -1;
        }
        //No key pressed
        if (!Input.GetKey(controls.strafeRight) && !Input.GetKey(controls.strafeLeft))
        {
            inputs.x = 0;
        }
        if (Input.GetKeyDown(controls.run))
        {
            switch (run)
            {
                case true:
                    run = false;
                    break;
                case false:
                    run = true;
                    break;
            }
        }
        //Go upwards

        if (Input.GetKey(controls.upwards))
        {
            swim += 1;
        }
        if (Input.GetKey(controls.downwards))
        {
            swim -= 1;
        }
        if (!Input.GetKey(controls.upwards) && !Input.GetKey(controls.downwards))
        {
            swim = 0;
        } 
    }
    void RotationInputs()
    {
        rotation = Input.GetAxis("Horizontal");
    }
}