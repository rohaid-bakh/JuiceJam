using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction movement;
    public float movementSpeed = 3.0f;

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
        transform.Translate(input.x * Time.deltaTime * movementSpeed, input.y * Time.deltaTime * movementSpeed, 0);
    }
}