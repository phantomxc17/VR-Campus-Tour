using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform orientation;

    public float controllerDeadZone = 0.25f;

    public GameObject footstep;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private float ApplyDeadZone(float value)
{
    if (Mathf.Abs(value) < controllerDeadZone)
    {
        return 0f;
    }
    else
    {
        // Adjust the value to account for the dead zone
        float adjustedValue = (Mathf.Abs(value) - controllerDeadZone) / (1 - controllerDeadZone);
        return Mathf.Sign(value) * adjustedValue;
    }
}



    private void MyInput()
    {
        // Keyboard input
        /*
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        */

        // Controller input
        // Controller input with dead zone
        
        horizontalInput = ApplyDeadZone(Input.GetAxisRaw("Horizontal"));
        verticalInput = ApplyDeadZone(Input.GetAxisRaw("Vertical"));

        if(horizontalInput == 0 && verticalInput == 0)
        {
            footstep.SetActive(false);
        }
        else footstep.SetActive(true);

        /*
        // Xbox Controller input
        float horizontalInput = Input.GetAxis("JoystickHorizontal");
        float verticalInput = Input.GetAxis("JoystickVertical");
        */
    }


    private void MovePlayer()
    {
        // Get the rotation of the main camera
        Quaternion headRotation = Camera.main.transform.rotation;

        // Convert the rotation to Euler angles
        Vector3 headEulerAngles = headRotation.eulerAngles;

        // Extract Y rotation for left/right movement
        float headYRotation = headEulerAngles.y;

        // Calculate movement direction based on head angle
        Vector3 moveDirectionWithHead = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirectionWithHead = Quaternion.Euler(0, headYRotation, 0) * moveDirectionWithHead;

        rb.AddForce(moveDirectionWithHead.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
