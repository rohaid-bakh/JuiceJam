using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossStats _stats;
    [SerializeField] private float CurrHealth;
    private SpriteRenderer renderer;
    private Material defaultMaterial;
    private bool invunerable;

    void Awake()
    {
        CurrHealth = _stats.healthAmount;
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;
    }

    public void takeDamage(float damage)
    {   
        if(!invunerable){
        CurrHealth -= damage;
        StartCoroutine(HitFlash());
        StartCoroutine(Invunerable());

        }
        if (CurrHealth <= 0)
        {
           DestroySelf();
        }
    
    }

    public IEnumerator Invunerable(){
        invunerable = true;
        yield return new WaitForSeconds(1f);
        invunerable = false;
    }
    private void DestroySelf(){
        
        Instantiate(_stats.BossExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private IEnumerator HitFlash(){
       
        renderer.material = _stats.hitFlash;
        yield return new WaitForSeconds(_stats.flashDuration);
        renderer.material = defaultMaterial;

    }
}
