using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float force;
    public float maxVelocity;
    public Rigidbody rb;
    public Camera cam;
    public Vector3 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        KeepOnScreen();
        rotateToFace();
    }
    private void FixedUpdate()
    {
        if(movementDirection == Vector3.zero)
        {
            return;
        }
        rb.AddForce(movementDirection*force*Time.deltaTime,ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    public void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = cam.ScreenToWorldPoint(touchPosition);
            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0;
            movementDirection.Normalize();

        }
        else
        {
            movementDirection = Vector3.zero;

        }
    }
    public void KeepOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = cam.WorldToViewportPoint(newPosition);
        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if(viewportPosition.x< 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        if (viewportPosition.y>1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if(viewportPosition.y<0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }
        transform.position = newPosition;
    }
    public void rotateToFace()
    {
        if(rb.velocity == Vector3.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);
        transform.rotation = targetRotation;
    }
}

