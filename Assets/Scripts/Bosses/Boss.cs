using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] protected BossStats _stats;
    [SerializeField] private float CurrHealth;
    private SpriteRenderer renderer;
    protected Material defaultMaterial;
    public bool invunerable;
    [SerializeField]private SceneTransit script;

    void Awake()
    {
        CurrHealth = _stats.healthAmount;
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;
    }

    public virtual void takeDamage(float damage)
    {   
        if(!invunerable){
        CurrHealth -= damage;
        StartCoroutine(HitFlash());
        StartCoroutine(Invunerable());

        }
        if (CurrHealth <= 0)
        {
            script.EndScene();
           DestroySelf();
           
        }
    
    }

    public IEnumerator Invunerable(){
        invunerable = true;
        yield return new WaitForSeconds(.5f);
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

    public void setInvunerable(){
        invunerable = !invunerable;
    }
}
