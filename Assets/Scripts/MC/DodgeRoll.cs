using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DodgeRoll : MonoBehaviour
{
    [SerializeField] protected Collider2D hitbox;
    protected PlayerInput _playerInputActions;
    private float dodgeTime = 1f;
    void Awake()
    {
        _playerInputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInputActions.Movement.Enable();
        _playerInputActions.Movement.DodgeRoll.performed += _ => Dodge();
    }

    private void OnDisable()
    {
        _playerInputActions.Movement.Disable();
        _playerInputActions.Movement.DodgeRoll.Disable();
    }

    private void Dodge(){
        hitbox.enabled = false;
        StartCoroutine(ReturnHitbox());
    }

    private IEnumerator ReturnHitbox(){
        yield return new WaitForSeconds(dodgeTime);
        hitbox.enabled = true;
    }

}
