using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    
    public Transform player;


    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = player.position.z;  
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, player.eulerAngles.z);
    }
}
