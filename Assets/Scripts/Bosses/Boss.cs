using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossStats _stats;
    [SerializeField] private float CurrHealth;

    void Awake()
    {
        CurrHealth = _stats.healthAmount;
    }

    public void takeDamage(float damage)
    {
        CurrHealth -= damage;
        if (CurrHealth <= 0)
        {
           DestroySelf();
        }
    }

    private void DestroySelf(){
        Destroy(gameObject);
    }
}
