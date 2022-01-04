using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction movement;
    public float movementSpeed = 3.0f;
    float smooth = 3.0f;

    void Awake()

    {
        playerInput = new PlayerInput();
        movement = new InputAction();
    }

    void OnEnable()
    {
        movement = playerInput.Movement.Move;
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 input = movement.ReadValue<Vector2>();

        //Rotation

        switch (input)
        {
            case var _ when input.y < 0:
                Quaternion newRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smooth);
                break;
            case var _ when input.y > 0:
                newRotation = Quaternion.Euler(0, 0, 180);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smooth);
                break;
            case var _ when input.x < 0:
                newRotation = Quaternion.Euler(0, 0, 270);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smooth);
                break;
            case var _ when input.x > 0:
                newRotation = Quaternion.Euler(0, 0, 90);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smooth);
                break;
        }

        //Movement
        transform.position = transform.position + new Vector3(input.x * Time.deltaTime * movementSpeed, input.y * Time.deltaTime * movementSpeed, 0);
    }
}