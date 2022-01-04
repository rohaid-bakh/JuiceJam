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
    void Awake()
    {
        _playerInputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInputActions.Attack.Enable();
        _playerInputActions.Attack.Melee.performed += _ => Attack();
    }

    private void OnDisable()
    {
        _playerInputActions.Attack.Disable();
        _playerInputActions.Attack.Melee.Disable();
    }

    public void Attack(){
        Debug.Log("Pressed Melee");
        Collider2D[] bosses = Physics2D.OverlapCircleAll(weapon.position, weaponRange, bossLayer);

        foreach(Collider2D boss in bosses) {
            Debug.Log("Caught Boss");
        }
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(weapon.position, weaponRange);
    }
}
