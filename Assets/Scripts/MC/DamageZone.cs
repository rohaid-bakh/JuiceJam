using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();

        if (controller != null)
        {
            controller.playerDamage(-1);
        }
    }
}
