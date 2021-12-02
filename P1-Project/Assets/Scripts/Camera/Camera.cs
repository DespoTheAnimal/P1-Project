using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was copied from Soupertrooper's video about camera movement - https://youtu.be/oKBUG89i5JA

public class Camera : MonoBehaviour
{

    // Mouse inputs
    KeyCode leftMouse = KeyCode.Mouse0, rightMouse = KeyCode.Mouse1;

    // Camera variables
    private float cameraHeight = 1.75f, cameraMaxDistance = 25;
    // Readonly float can only be changed in this line
    readonly float cameraMaxTilt = 75;
    public float cameraSpeed = 2;
    float currentPan, currentTilt = 10, currenDistance = 5;


    public Controls controls;


    // References 
    PlayerMovement1 player;
    public Transform tilt;
    [SerializeField]
    Camera mainCamera;

    void Start()
    {
        // Player is getting the script "PlayerMovement1" into the Camera script
        player = FindObjectOfType<PlayerMovement1>();

        // Sets the player's "mainCam" to this script
        player.mainCam = this;

        // Transforming the camera's position according to the players position & rotation
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        // Tilts the camera with currentTilt's value
        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCamera.transform.position += tilt.forward * -currenDistance;
        

    }


    void Update()
    {
        CameraInputs();
    }

    private void LateUpdate()
    {
        CameraTransforms();
    }

    void CameraInputs()
    {
       
        currentPan += Input.GetAxis("Mouse X") * cameraSpeed;
        currentTilt -= Input.GetAxis("Mouse Y") * cameraSpeed;
        currentTilt = Mathf.Clamp(currentTilt, -cameraMaxTilt, cameraMaxTilt);

    }
    void CameraTransforms()
    {

                currentPan = player.transform.eulerAngles.y;
                player.strafeLeft = KeyCode.A;
                player.strafeRight = KeyCode.D;
                Cursor.lockState = CursorLockMode.Locked;



        //Cameras rotate is the same as the players
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCamera.transform.position = transform.position + tilt.forward * -currenDistance;
    }


}
