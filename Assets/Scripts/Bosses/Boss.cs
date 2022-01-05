using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossStats _stats;
    [SerializeField] private float CurrHealth;
    [SerializeField] private Material hitFlash;
    private SpriteRenderer renderer;
    private Material defaultMaterial;
    [SerializeField] private float flashDuration;
    void Awake()
    {
        CurrHealth = _stats.healthAmount;
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;
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

    private void DestroySelf(){
        Destroy(gameObject);
    }

    private IEnumerator HitFlash(){
        renderer.material = hitFlash;
        yield return new WaitForSeconds(flashDuration);
        renderer.material = defaultMaterial;

    }
}
