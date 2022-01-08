using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenController : MonoBehaviour
{
    [SerializeField] private BossStats _stats;
    [SerializeField] private float CurrHealth;
    private SpriteRenderer renderer;
    private Material defaultMaterial;

    [SerializeField] private float movementCooldown = 1f;
    Vector2 position1 = new Vector2(-60, 0);
    Vector2 position2 = new Vector2(60, 0);
    [SerializeField] float speed = 3.0f;
    int direction = 1;
    bool movement = true;

    void Awake()
    {
        CurrHealth = _stats.healthAmount;
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;
    }

    void FixedUpdate()
    {
        if (movement)
        {
            switch (direction)
            {
                case -1:
                    transform.position = Vector2.MoveTowards(transform.position, position1, speed * Time.deltaTime);
                    movement = false;
                    direction = 1;
                    StartCoroutine(MovementCooldown());
                    break;

                case 1:
                    transform.position = Vector2.MoveTowards(transform.position, position2, speed * Time.deltaTime);
                    movement = false;
                    direction = -1;
                    StartCoroutine(MovementCooldown());
                    break;
            }
        }
    }

    public void takeDamage(float damage)
    {
        CurrHealth -= damage;
        StartCoroutine(HitFlash());
        if (CurrHealth <= 0)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Instantiate(_stats.BossExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(movementCooldown);
        movement = true;
    }

        private IEnumerator HitFlash()
    {
        renderer.material = _stats.hitFlash;
        yield return new WaitForSeconds(_stats.flashDuration);
        renderer.material = defaultMaterial;
    }

    //void OnDrawGizmos()
    //{
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(position1, 2f);
        //Gizmos.DrawWireSphere(position2, 2f);
    //}
}
