using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Swim : MonoBehaviour
{

    protected Rigidbody rb;
    protected Rigidbody rbTarget;
    [SerializeField]
    protected float speed;

    protected RaycastHit Hit;


    protected bool CastRay(float distance)
    {
        if (Physics.Raycast(rb.position, transform.forward, out Hit, distance))
            return true;
        else return false;
        
    }
    protected void DefaultMove()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }

    protected void RotateDirection()
    {
        rb.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
    }

    abstract protected void MoveByPlayer();

    abstract protected void Move();

    

}
