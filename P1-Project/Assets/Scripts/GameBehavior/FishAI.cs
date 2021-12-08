using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{

    Rigidbody rb;

    float speed = 10f;

    RaycastHit Hit;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FriendlyMove();
    }

    void DefaultMove()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }
    void FriendlyMove()
    {
        if (Physics.Raycast(rb.position, transform.forward, out Hit, 2f))
        {

            rb.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        }
        else
        {
            DefaultMove();
        }
    }
}