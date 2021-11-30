using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Player _player;
    Vector3 cameraPosition;
    [SerializeField]
    Vector3 cameraOffset;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _player.GetComponent<Rigidbody>();
        _player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        thirdPerson();
    }

    void thirdPerson()
    {
        // cameraOffset = new Vector3(0, 2, -5);
        cameraPosition = new Vector3(_player.transform.position.x,_player.transform.position.y,_player.transform.position.z) + cameraOffset;
        this.transform.position = cameraPosition;
    }
}
