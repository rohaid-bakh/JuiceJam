using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PlayerHealth : MonoBehaviour
{
    float maxHealth = 5.0f;
    public float currentHealth;
    bool isDamage = false;
    [SerializeField] private Material hitFlash;
    private SpriteRenderer renderer;
    private Material defaultMaterial;
    [SerializeField] private float flashDuration;

    [Header("Sound")]
    [SerializeField] protected MC_Sounds _sounds; 
    AudioSource source;

    void Start()
    {
        currentHealth = maxHealth;
        source = GetComponent<AudioSource>();
    }

    void Awake() {
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;
    }

    public void playerDamage(float damage)
    {
        if(!isDamage){
        source.clip = _sounds.hurtSound;
        source.pitch = 1f;
        source.Play();
        currentHealth += damage;
        isDamage = true;
        StartCoroutine(HitFlash());
        Debug.Log("Current player health:" + currentHealth);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead. Game over.");
            SceneManager.LoadScene(sceneName: "GameOver");
        }

    }

    private IEnumerator HitFlash(){
        renderer.material = hitFlash;
        yield return new WaitForSeconds(flashDuration);
        renderer.material = defaultMaterial;
        isDamage = false;

    }


}
