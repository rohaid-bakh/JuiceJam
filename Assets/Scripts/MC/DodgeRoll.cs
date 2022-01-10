using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DodgeRoll : MonoBehaviour
{
    [SerializeField] protected Collider2D hitbox;
    protected PlayerInput _playerInputActions;
    private float dodgeTime = 1f;
    private float fixedDeltaTime;

    [Header("Sound")]
    [SerializeField] protected MC_Sounds _sounds; 
    AudioSource source;

    [Header("Pause")]
    protected PlayerController script;

    void Awake()
    {
        _playerInputActions = new PlayerInput();
        fixedDeltaTime = Time.fixedDeltaTime;
        source = GetComponent<AudioSource>();
        script = GetComponent<PlayerController>();
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
        if(hitbox.enabled && !script.pause){
        source.clip = _sounds.dodgeSound;
        source.pitch = 1;
        source.Play();
        hitbox.enabled = false;
        StartCoroutine(ReturnHitbox());
        }
    }

    private IEnumerator ReturnHitbox(){
        Time.timeScale = .5f;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        yield return new WaitForSeconds(dodgeTime);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
        hitbox.enabled = true;
    }

}
