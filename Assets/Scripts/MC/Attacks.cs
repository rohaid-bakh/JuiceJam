using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attacks : MonoBehaviour
{
    
    protected PlayerInput _playerInputActions;
    [Header("Ranged Weapon Direction")]
    [SerializeField] protected Transform[] weapon;
    // 0 is Left, 1 is Right , 2 is Up, 3 is Down
    public int direction;
    [Header("Ranged Weapon")]
    [SerializeField] private MeleeStats _meleeStats;
    

    [Header("Projectile Stats")]
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected Transform shotPoint;
    
   
    [Header("Cool Down")]
    [SerializeField] private float rangeCooldown = .3f;
    [SerializeField] private float meleeCooldown = .6f;
    private bool meleeAttack = true;
    private bool rangedAttack = true;

    
   
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
        _playerInputActions.Attack.Ranged.Disable();
    }

    public void MeleeAttack()
    {
        if (meleeAttack)
        {
            Collider2D[] bosses = Physics2D.OverlapCircleAll(weapon[direction].position, _meleeStats.weaponRange, _meleeStats.bossLayer);
            foreach (Collider2D boss in bosses)
            {
                boss.GetComponent<Boss>().takeDamage(_meleeStats.damage);
                CameraShake.Trauma = 0.22f;
            }
            meleeAttack = false;
            StartCoroutine(MeleeAttackWait());
        }
    }
    public void RangedAttack()
    {
        if (rangedAttack)
        {
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            rangedAttack = false;
            CameraShake.Trauma = 0.4f;
            StartCoroutine(RangedAttackWait());
        }
    }
    protected IEnumerator MeleeAttackWait()
    {
        yield return new WaitForSeconds(_meleeStats.coolDown);
        meleeAttack = true;
    }
    protected IEnumerator RangedAttackWait()
    {
        yield return new WaitForSeconds(rangeCooldown);
        rangedAttack = true;
    }

    // UNCOMMENT WHEN DEBUGGING
    void OnDrawGizmos()
    {
        if (weapon == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(weapon[direction].position, _meleeStats.weaponRange);
    }
}
