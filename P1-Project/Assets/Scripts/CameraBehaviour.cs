using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Player _player;
    Vector3 cameraPosition;
    [SerializeField]
    float cameraOffset;
    public float sens;

    [SerializeField]
    float turnSpeed;
    private Vector3 offset;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _player.GetComponent<Rigidbody>();
        _player.GetComponent<Transform>();
        
    }
    private void Start()
    {
        offset = new Vector3(_player.transform.position.x, _player.transform.position.y + 1.0f, _player.transform.position.z + 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var c = this.transform;
        //c.Rotate(0, Input.GetAxis("Mouse X") * sens, 0);
        //this.transform.LookAt(_player.transform.position);
       // thirdPerson();
        if (Input.GetMouseButtonDown(0))
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = _player.transform.position + offset;
        this.transform.LookAt(_player.transform.position);
    }

   /* void thirdPerson()
    {
        cameraOffset = new Vector3(0, 2, -5);
        cameraPosition = new Vector3(_player.transform.position.x,_player.transform.position.y,_player.transform.position.z + cameraOffset);
        this.transform.position = cameraPosition; 
      
    } */
} 
