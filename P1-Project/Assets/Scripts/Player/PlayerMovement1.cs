using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement1 : MonoBehaviour
{
    public KeyCode strafeLeft, strafeRight, sprint = KeyCode.LeftShift;
    //public Controls controls;
    public float hoverSpeed = 50f;
    private float activeHoverSpeed;
    private float hoveAcceleration = 2f;
    [SerializeField]
    Vector2 inputs;
    int swimUp;
    [SerializeField]
    float rotation;
    float pan;
    Vector3 vel;
    public float baseSpeed = 4f, runSpeed = 8f, rotateSpeed = 4f;

    [SerializeField]
    StaminaBar staminaBar;
    int maxStamina;
    int minStamina = 0;
    int curStamina;
    int staminaUse = 15;
    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;

    [SerializeField]
    bool run = true;

    [HideInInspector]
    public bool steer;

    // Tells the player script to refer to the camera script by mainCam for the GameObject Camera
    [HideInInspector]
    public Camera mainCam;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        strafeLeft = KeyCode.Q;
        strafeRight = KeyCode.E;
        maxStamina = 100;
        curStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);

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
        Vector3 rotate = transform.eulerAngles + new Vector3(0, rotation * rotateSpeed, 0);
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
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, swimUp * hoverSpeed, hoveAcceleration * Time.deltaTime);
        rb.position += (transform.up * activeHoverSpeed * Time.deltaTime);
    }

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

        if (steer)
        {

            inputs.x = Mathf.Clamp(inputs.x, -1, 1);
        }
        //No key pressed
        if (!Input.GetKey(strafeRight) && !Input.GetKey(strafeLeft))
        {
            inputs.x = 0;
        }
        if (Input.GetKey(sprint)) //&& curStamina > maxStamina/2)
        {
            SetStamina(maxStamina-1);
        }
        //Go upwards
        if (Input.GetKey(upwards))
        {
            swimUp = 1;
        }
        //No key pressed
        if (!Input.GetKey(upwards))
        {
            swimUp = 0;
        }
    }

    void SetStamina(int amount)
    {
        if (curStamina - amount > minStamina)
        {
            run = true;
            curStamina -= amount;
            staminaBar.SetStamina(curStamina);

            if (regen != null)
                StopCoroutine(regen);
            Invoke("testRun", 3f);
        regen = StartCoroutine(RegenStamina());
        }
            
    }

    private void testRun()
    {
        run = false;
    }
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
    void RotationInputs()
    {

        Vector3 rotate = transform.eulerAngles + new Vector3(-pan, rotation * rotateSpeed, 0);
        transform.eulerAngles = rotate;
        rotation = Input.GetAxis("Mouse X") * mainCam.cameraSpeed;
        pan = Input.GetAxis("Mouse Y") * mainCam.cameraSpeed;

    }
}