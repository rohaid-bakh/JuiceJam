using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SteamKing : Boss
{
    [SerializeField] private SteamSound _sound;
    private AudioSource source;
    [SerializeField] private Transform Player;
    private Transform Boss;
    private Rigidbody2D rb;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject steam;
    [SerializeField] private Transform shotPoint;
    private bool rangedAttack = true;
    private float meleeCoolDown = 1f;
    void Start()
    {
        Boss = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    public override void takeDamage(float damage)
    {
        if(!source.isPlaying){
        source.clip = _sound.hurtSound;
        source.Play();
        }
        base.takeDamage(damage);

    }

    public void Shoot(string phase)
    {
        Vector2 lookDir = (Vector2)Player.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle;
        shotPoint.localRotation = Quaternion.Euler(0f, 0f, 90f);

        if (rangedAttack && phase == "Bullet")
        { //Could write with a forloop honestly
            source.clip = _sound.bulletSound;
            source.Play();
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            shotPoint.localRotation = Quaternion.Euler(0f, 0f, 120f);
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            shotPoint.localRotation = Quaternion.Euler(0f, 0f, 150f);
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            rangedAttack = false;
            CameraShake.Trauma = 0.4f;
            StartCoroutine(RangedAttackWait());
        }
        else if (rangedAttack && phase == "Steam")
        {
            source.clip = _sound.steamSound;
            source.Play();
            float randRot = Random.Range(90f, 160f);
            shotPoint.localRotation = Quaternion.Euler(0f, 0f, randRot);
            Instantiate(steam, shotPoint.position, shotPoint.rotation);
            rangedAttack = false;
            CameraShake.Trauma = 0.3f;
            StartCoroutine(RangedAttackWait());
        }
    }
    public void Reset()
    {
        Boss.rotation = Quaternion.identity;
        rb.rotation = 0f;
    }

    protected IEnumerator RangedAttackWait()
    {
        yield return new WaitForSeconds(meleeCoolDown);
        rangedAttack = true;
    }


}
