using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    float maxHealth = 5.0f;
    float currentHealth;

    [SerializeField] private Material hitFlash;
    private SpriteRenderer renderer;
    private Material defaultMaterial;
    [SerializeField] private float flashDuration;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Awake() {
        renderer = GetComponent<SpriteRenderer>();
        defaultMaterial = renderer.material;
    }

    public void playerDamage(float damage)
    {
        currentHealth += damage;
        StartCoroutine(HitFlash());
        Debug.Log("Current player health:" + currentHealth);

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

    }


}
