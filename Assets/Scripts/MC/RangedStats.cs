using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedStats", menuName = "MC/RangedStats")]
public class RangedStats : ScriptableObject{

    public float damage;
    public float weaponRange;
    public float coolDown;
    public LayerMask bossLayer;
}
