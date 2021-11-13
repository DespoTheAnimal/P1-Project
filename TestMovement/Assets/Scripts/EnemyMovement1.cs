using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement1 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    Rigidbody rbTarget;

    float speed = 1;

    RaycastHit Hit;

    Rigidbody rb;

    void Start()
    {
        target = GameObject.Find("Player");
        rbTarget = target.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    void Move()
    {
        float distanceToTarget = Vector3.Distance(rb.position, rbTarget.position);
        float FollowDistance = 3f;
        if (distanceToTarget < FollowDistance)
        {
            rb.position = Vector3.MoveTowards(rb.position, rbTarget.position, speed * Time.deltaTime);
        } //else //(Physics.Raycast(rb.position, transform.forward, out Hit)){
          // Debug.Log("Found Destination");
          // agent.Move(transform.forward);
          // if (Vector3.Distance(rb.position, Hit.transform.position) < 1f)
          //  {
          //    transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
          //    Debug.Log(transform.rotation);
          // }
          // }
    }
    void MoveTo(Vector3 direction)
    {
        Vector3 prevpos = rb.position;
        Vector3 newPos = prevpos + (direction * speed);
        rb.position = newPos;
    }
}
