using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeStats", menuName = "MC/MeleeStats")]
public class MeleeStats : ScriptableObject{

    public float damage;
    public float weaponRange;
    public float coolDown;
    public LayerMask bossLayer;
}
