using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //input
    KeyCode leftMouse = KeyCode.Mouse0, rightMouse = KeyCode.Mouse1, middleMouse = KeyCode.Mouse2;

    // Camera variables
    public float cameraHeight = 1.75f, cameraMaxDistance = 25;
    readonly float cameraMaxTilt = 90;
    [Range(0,4)]
    public float cameraSpeed = 2;
    float currentPan, currentTilt = 15, currenDistance = 10;

    //Camera State
    public CameraState cameraState = CameraState.CameraNone;


    //references
    PlayerMovement1 player;
    public Transform tilt;
    [SerializeField]
    Camera mainCamera;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement1>();
        //mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

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
