using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    [SerializeField] private ProjectileStats _stats;
    bool isDamage = false;
    private Rigidbody2D rb;

    private float maxTime = .6f;
    private float minTime = 0f;
    private float timeCount;
    bool end = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeCount = maxTime;
    }

    void FixedUpdate()
    {
        float multiplier = Random.Range(10f,13f) * .34f;
        if(timeCount <= minTime && !end){
            end = true;
            StartCoroutine(DestroySteam());
        } else if(!end) {
            timeCount -= Time.fixedDeltaTime;
            transform.Translate(Vector2.up * _stats.speed* multiplier * Time.fixedDeltaTime);
        }
        
    }
    
    protected IEnumerator DestroySteam()
    {
         yield return new WaitForSeconds(10f);
        Instantiate(_stats.explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && !isDamage){
           other.gameObject.GetComponent<PlayerHealth>().playerDamage(-1);
           isDamage = true;
           StartCoroutine(DamageLag());
        }
    }
     private IEnumerator DamageLag() {
        yield return new WaitForSeconds(1f);
        isDamage = false;
    }
}
