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
    float currentPan, currentTilt = 10, currenDistance = 5;

    //references
    PlayerMovement player;
    public Transform tilt;
    [SerializeField]
    Camera mainCamera;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        //mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCamera.transform.position += tilt.forward * -currenDistance;
    }

    
    void Update()
    {
        CameraTransforms();
    }

    void CameraTransforms()
    {
        //Cameras rotate is the same as the players
        currentPan = player.transform.eulerAngles.y;
        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCamera.transform.position = transform.position + tilt.forward * -currenDistance;
    }
}
