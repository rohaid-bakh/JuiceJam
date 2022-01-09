using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileStats _stats;
   

    void Start()
    {
        Invoke("DestroyProjectile", _stats.lifeTime);
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _stats.distance, _stats.bossLayer);
        if (hitInfo.collider != null){
            if(hitInfo.collider.GetComponent<Boss>() != null){
                hitInfo.collider.GetComponent<Boss>().takeDamage(_stats.damageAmount);
            } else if(hitInfo.collider.GetComponent<PlayerHealth>() != null) {
            hitInfo.collider.GetComponent<PlayerHealth>().playerDamage(-1);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * _stats.speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        CameraShake.Trauma = 0.2f;
        Instantiate(_stats.explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
