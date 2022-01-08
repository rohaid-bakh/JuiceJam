using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamKing : Boss
{
    [SerializeField] private Transform Player;
    private Transform Boss;
    private Rigidbody2D rb;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shotPoint;
    private bool rangedAttack = true;
    private float meleeCoolDown = 1f;
    void Start() {
        Boss = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Shoot(){
        Vector2 lookDir = (Vector2)Player.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle;
        shotPoint.localRotation = Quaternion.Euler(0f, 0f, 90f);
        if (rangedAttack)
        {
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            shotPoint.localRotation = Quaternion.Euler(0f, 0f, 120f);
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            rangedAttack = false;
            CameraShake.Trauma = 0.4f;
            StartCoroutine(MeleeAttackWait());
        }
    }
    public void Reset(){
          Boss.rotation = Quaternion.Euler(0, 0, 0);;
    }

     protected IEnumerator MeleeAttackWait()
    {
        yield return new WaitForSeconds(meleeCoolDown);
        rangedAttack = true;
    }


}
