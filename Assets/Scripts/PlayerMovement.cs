using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float movementSpeed = 2;
    public float rotationMultiplier = 20;
    public float mouseSensitivity;
    public float verticalRotation;
    public float horizontalRotation;
    public float maxVerticalRotation = 45;
    CharacterController controller;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
        
        
    }

    void Rotate()
    {
        horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalRotation, maxVerticalRotation);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0 ,0);


    }

    void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        direction = new Vector3(horizontalInput * movementSpeed, 0, verticalInput * movementSpeed);
        direction = Vector3.ClampMagnitude(direction, movementSpeed);
        direction = transform.TransformDirection(direction);

        controller.Move(direction * Time.deltaTime);
        
    }
}
