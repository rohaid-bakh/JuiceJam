using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossStats", menuName = "Boss/Stats")]
public class BossStats : ScriptableObject
{
    public string bossName;
    public int damageAmount;
    public int healthAmount;
    public float attackCoolDown;
    public float speed;
    public AudioClip Hit;

}
