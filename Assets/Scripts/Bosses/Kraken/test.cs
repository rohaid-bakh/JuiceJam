using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private float movementCooldown = 1f;
    Rigidbody2D rb;
    Vector2 position1 = new Vector2(-60, 0);
    Vector2 position2 = new Vector2(60, 0);
    [SerializeField] float speed = 3.0f;
    int direction = 1;
    bool movement = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movement)
        {
            if (transform.position.x >= -60)
            {
                transform.position = Vector2.MoveTowards(rb.position, position1, speed * Time.deltaTime);
            }
            else if (transform.position.x <= 60)
            {
                transform.position = Vector2.MoveTowards(rb.position, position2, speed * Time.deltaTime);
            }

        }

    }
    void Movement()
    {
        transform.position = Vector2.MoveTowards(rb.position, position1, speed * Time.deltaTime);
        Debug.Log(transform.position);
    }

    private IEnumerator MovementCooldown()
    {
        Debug.Log("Coroutine has begun.");
        yield return new WaitForSeconds(movementCooldown);
        movement = true;
    }
}
