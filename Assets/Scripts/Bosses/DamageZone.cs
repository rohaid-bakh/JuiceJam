using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    bool isDamage = false;
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();

        if (controller != null && !isDamage)
        {
            controller.playerDamage(-1);
            isDamage = true;
            CameraShake.Trauma = 0.3f;
            StartCoroutine(DamageLag());
        }
    }

    private IEnumerator DamageLag() {
        yield return new WaitForSeconds(1f);
        isDamage = false;
    }
}
