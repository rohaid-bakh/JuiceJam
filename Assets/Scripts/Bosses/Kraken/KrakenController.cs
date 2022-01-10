using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenController : MonoBehaviour
{
    [SerializeField] private BossStats _stats;
    [SerializeField] private float CurrHealth;
    private SpriteRenderer renderer;
    private Material defaultMaterial;

    Rigidbody2D rb;

    void Awake()
    {
        CurrHealth = _stats.healthAmount;
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;

        rb = GetComponent<Rigidbody2D>();
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
