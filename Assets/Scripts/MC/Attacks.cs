using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attacks : MonoBehaviour
{
    protected PlayerInput _playerInputActions;
    [SerializeField] protected Transform weapon;
    [SerializeField] protected float weaponRange;
    public LayerMask bossLayer;
    private bool meleeAttack = true;
    private bool rangedAttack = true;
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected Transform shotPoint;
    void Awake()
    {
        _playerInputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInputActions.Attack.Enable();
        _playerInputActions.Attack.Melee.performed += _ => MeleeAttack();
        _playerInputActions.Attack.Ranged.performed += _ => RangedAttack();
    }

    private void OnDisable()
    {
        _playerInputActions.Attack.Disable();
        _playerInputActions.Attack.Melee.Disable();
    }

    public void MeleeAttack()
    {
        if (meleeAttack)
        {
            Collider2D[] bosses = Physics2D.OverlapCircleAll(weapon.position, weaponRange, bossLayer);
            foreach (Collider2D boss in bosses)
            {
                boss.GetComponent<Boss>().takeDamage(10f);
            }
            meleeAttack = false;
            StartCoroutine(MeleeAttackWait());
        }
    }

    public void RangedAttack()
    {
        if (rangedAttack)
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
            rangedAttack = false;
            StartCoroutine(RangedAttackWait());
        }
    }
    protected IEnumerator MeleeAttackWait()
    {
        yield return new WaitForSeconds(1f);
        meleeAttack = true;
    }
    protected IEnumerator RangedAttackWait()
    {
        yield return new WaitForSeconds(1f);
        rangedAttack = true;
    }

    //UNCOMMENT WHEN DEBUGGING
    // void OnDrawGizmos()
    // {
    //     if (weapon == null) return;

    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(weapon.position, weaponRange);
    // }
}
