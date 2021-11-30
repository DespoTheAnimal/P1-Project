using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwimOrFly : MonoBehaviour
{

    public float fowardSpeed = 25f, strafeSpeed = 25f, hoverSpeed = 15f;
    private float activeHoverSpeed;
    private float hoveAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    [SerializeField]
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Move();    

    }

    private void Move()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoveAcceleration * Time.deltaTime);

        rb.position +=  (transform.up * activeHoverSpeed * Time.deltaTime);
    }
}
