using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was copied from Soupertrooper's video about camera movement - https://youtu.be/oKBUG89i5JA

public class Camera : MonoBehaviour
{

    // Mouse inputs
    KeyCode leftMouse = KeyCode.Mouse0;

    // Camera variables
    private float cameraHeight = 1.75f, cameraMaxDistance = 25;
    // Readonly float can only be changed in this line
    readonly float cameraMaxTilt = 90;
    private float cameraSpeed = 2;
    float currentPan, currentTilt = 10, currenDistance = 5;

    // CameraState(s) from the enum
    public CameraState cameraState = CameraState.CameraNone;


    // References 
    PlayerMovement1 player;
    public Transform tilt;
    [SerializeField]
    Camera mainCamera;

    void Start()
    {
        // Player is getting the script "PlayerMovement1" into the Camera script
        player = FindObjectOfType<PlayerMovement1>();

        // Transforming the camera's position according to the players position & rotation
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        // Tilts the camera with currentTilt's value
        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCamera.transform.position += tilt.forward * -currenDistance;
    }

    
    void Update()
    {
        if (Input.GetKey(leftMouse))
            cameraState = CameraState.CameraRotate;
        else
            cameraState = CameraState.CameraNone;
        CameraInputs();
    }

    private void LateUpdate()
    {
        CameraTransforms();
    }

    void CameraInputs()
    {
        if(cameraState != CameraState.CameraNone)
           currentPan += Input.GetAxis("Mouse X") * cameraSpeed;
        currentTilt -= Input.GetAxis("Mouse Y") * cameraSpeed;
        currentTilt = Mathf.Clamp(currentTilt, -cameraMaxTilt, cameraMaxTilt);
    }
    void CameraTransforms()
    {
        switch(cameraState)
        {
            case CameraState.CameraNone:
                currentPan = player.transform.eulerAngles.y;
                currentTilt = 10;
                break;
        }

        //Cameras rotate is the same as the players
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCamera.transform.position = transform.position + tilt.forward * -currenDistance;
    }

    public enum CameraState { CameraNone, CameraRotate }
}
