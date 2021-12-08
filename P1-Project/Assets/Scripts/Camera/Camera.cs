using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was copied from Soupertrooper's video about camera movement - https://youtu.be/oKBUG89i5JA

public class Camera : MonoBehaviour
{

    // Camera variables
    private float cameraHeight = 1.75f;
    // Readonly float can only be changed in this line
    //tilt of the camera
    readonly float cameraMaxTilt = 75;
    //The sensitivity of the mouse
    public float cameraSpeed = 2;
    public float cameraExtraSpeed = 2;
    //variables for pan, tilt and distance
    float currentPan, currentTilt = 10, currenDistance = 5;



    // References 
    PlayerMovement player;
    public Transform tilt;
    [SerializeField]
    Camera mainCamera;

    void Start()
    {
        // Player is getting the script "PlayerMovement1" into the Camera script
        player = FindObjectOfType<PlayerMovement>();
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

    /// <summary>
    /// Sets the variables of the pan and tilt of the camera to be relative to mouse inputs
    /// </summary>
    void CameraInputs()
    {
        currentPan += Input.GetAxis("Mouse X") * cameraSpeed;
        currentTilt -= Input.GetAxis("Mouse Y") * cameraSpeed * cameraExtraSpeed;
        currentTilt = Mathf.Clamp(currentTilt, -cameraMaxTilt, cameraMaxTilt);
    }

    void CameraTransforms()
    {
        currentPan = player.transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        //Cameras rotate is the same as the players
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCamera.transform.position = transform.position + tilt.forward * -currenDistance;
    }
}
