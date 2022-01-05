using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileStats", menuName = "MC/ProjectileStats")]
public class ProjectileStats : ScriptableObject
{
    public string projectileName;
    public int damageAmount;
    public float attackCoolDown;
    public float speed;
    public float distance;
    public float lifeTime;
    public LayerMask bossLayer;
    public GameObject explosion;
    public AudioClip launch;

}
