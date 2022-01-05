using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileStats _stats;
    [SerializeField] private LayerMask bossLayer;
    [SerializeField] private GameObject Explosion;

    void Start()
    {
        Invoke("DestroyProjectile", _stats.lifeTime);
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, _stats.distance, bossLayer);
        if (hitInfo.collider != null){
            hitInfo.collider.GetComponent<Boss>().takeDamage(_stats.damageAmount);
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * _stats.speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        CameraShake.Trauma = 0.2f;
        Instantiate(Explosion,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
