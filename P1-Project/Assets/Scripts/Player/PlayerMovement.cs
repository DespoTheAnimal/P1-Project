using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code inspiration from soupertrooper: https://www.youtube.com/watch?v=526OvMqEk_M

public class PlayerMovement : MonoBehaviour
{
    //variables for keycodes
    KeyCode upwards = KeyCode.Space, strafeLeft = KeyCode.A, strafeRight = KeyCode.D, sprint = KeyCode.LeftShift;

    //1 if the player should swim up 0 if not
    int swimUp;
    //The input being pressed
    Vector2 inputs;
    //the amount the gameobject should rotate
    float rotation;

    float pan;
    //Reference to the velocity of the gameobject
    Vector3 vel;
    //The speed variables
    float baseSpeed = 20f, runSpeed = 75f, rotateSpeed = 4f;

    //stamina properties
    [SerializeField]
    StaminaBar staminaBar;
    int maxStamina;
    int minStamina = 0;
    int curStamina;

    //A waitforseconds for the regen of the staminabar
    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;

    //true if the player is running
    [SerializeField]
    bool run = false;


    // Tells the player script to refer to the camera script by mainCam for the GameObject Camera
    [HideInInspector]
    public Camera mainCam;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //strafeLeft = KeyCode.Q;
        //strafeRight = KeyCode.E;
        maxStamina = 100;
        curStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);

    }

    // Update is called once per frame
    void Update()
    {
        GetPosInputs();
        RotationInputs();
        Motion();
        
    }
    /// <summary>
    /// Uses the inputs to set the velocity of the player
    /// </summary>
    void Motion()
    {
        //gets the inputs
        Vector2 inputNormalized = inputs;
        //Rotates the player depending on rotation input
        Vector3 rotate = transform.eulerAngles + new Vector3(0, rotation * rotateSpeed, 0);
        transform.eulerAngles = rotate;

        //sets speed to either runspeed or basespeed depending on wheter run is true or false
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
        //moves the player up or down depending on the keypresses       
        rb.position += (transform.up * swimUp * Time.deltaTime);
    }

    /// <summary>
    /// Sets the variables x and y inputs
    /// </summary>
    void GetPosInputs()
    {
        //Sets the y coordinate of the input (-1 to 1) depending on the key press
        inputs.y = Input.GetAxis("Vertical");
        //Strafe right
        if (Input.GetKey(strafeRight))
        {
            inputs.x = 1;
        }
        //Strafe left
        if (Input.GetKey(strafeLeft))
        {
            //If both keys are pressed, no strafing
            if (Input.GetKey(strafeRight))
            {
                inputs.x = 0;
            }
            else
                inputs.x = -1;
        }

        //No key pressed
        if (!Input.GetKey(strafeRight) && !Input.GetKey(strafeLeft))
        {
            inputs.x = 0;
        }
        if (Input.GetKey(sprint)) //&& curStamina > maxStamina/2)
        {
            SetStamina(maxStamina/2);
        }
        //Go upwards
        if (Input.GetKey(upwards))
        {
            swimUp = 10;
        }
        //No key pressed
        if (!Input.GetKey(upwards))
        {
            swimUp = 0;
        }
    }
    /// <summary>
    /// rotates the player
    /// </summary>
    void RotationInputs()
    {
        Vector3 rotate = transform.eulerAngles + new Vector3(-pan, rotation * rotateSpeed, 0);
        transform.eulerAngles = rotate;
        rotation = Input.GetAxis("Mouse X") * mainCam.cameraSpeed;
        pan = Input.GetAxis("Mouse Y") * mainCam.cameraSpeed * mainCam.cameraExtraSpeed;
    }
    /// <summary>
    /// Lets the player do a stamina boost if it has enough stamina
    /// </summary>
    /// <param name="amount">The amount of stamina it takes to run</param>
    void SetStamina(int amount)
    {
        if (curStamina - amount > minStamina)
        {
            run = true;
            curStamina -= amount;
            staminaBar.SetStamina(curStamina);

            if (regen != null)
                StopCoroutine(regen);
            //calls the run method after 2 seconds
            Invoke("Run", 2f);
            //begins to regen stamina
        regen = StartCoroutine(RegenStamina());
        }
            
    }
    /// <summary>
    /// sets run to true
    /// </summary>
    private void Run()
    {
        run = false;
    }
    /// <summary>
    /// After 2 seconds stamina increases while it is less than maxStamina
    /// </summary>

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (curStamina < maxStamina)
        {
            curStamina++;
            staminaBar.SetStamina(curStamina);
            yield return regenTick;
        }
        regen = null;
    } 

    public float Axis(bool pos, bool neg)
    {
        float axis = 0;

        if (pos)
            axis += 1;

        if (neg)
            axis -= 1;
        return axis;
    }

 
}