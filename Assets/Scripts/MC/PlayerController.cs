using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction movement;
    [Header("Movement")]
    public float movementSpeed = 3.0f;
    [Header("Animation")]
    [SerializeField] private Animator anim;
    private Vector2 prevInput;
    private Attacks attack;
    [Header("Direction")]
    [SerializeField] Transform shotPoint;

    void Awake()

    {
        playerInput = new PlayerInput();
        movement = new InputAction();
        attack = GetComponent<Attacks>();
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


    void FixedUpdate()
    {
        Vector2 input = movement.ReadValue<Vector2>().normalized;

        anim.SetFloat("Speed", input.sqrMagnitude); // Needed to see if at rest/not

        if (input.sqrMagnitude == 0)
        {
            //Idle
            anim.SetFloat("PrevX", prevInput.x);
            anim.SetFloat("PrevY", prevInput.y);
        }
        else
        {
            //Movement
            anim.SetFloat("XAxis", input.x);
            anim.SetFloat("YAxis", input.y);
            prevInput = input;
        }


        //Rotation
        switch (input)
        {
            case var _ when input.y < 0:
                shotPoint.rotation = Quaternion.Euler(0, 0, 180);
                attack.direction = 3;
                break;
            case var _ when input.y > 0:
                shotPoint.rotation = Quaternion.Euler(0, 0, 0);
                attack.direction = 2;
                break;
            case var _ when input.x < 0:
                shotPoint.rotation = Quaternion.Euler(0, 0, 90);
                attack.direction = 0;
                break;
            case var _ when input.x > 0:
                shotPoint.rotation = Quaternion.Euler(0, 0, 270);
                attack.direction = 1;
                break;

            case var _ when input.x == 0 && input.y == 0:
                break;
        }

        //Movement
        transform.position += new Vector3(input.x * Time.deltaTime * movementSpeed, input.y * Time.deltaTime * movementSpeed, 0);
    }
}