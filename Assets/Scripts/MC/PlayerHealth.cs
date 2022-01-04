using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    float maxHealth = 5.0f;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void playerDamage(float damage)
    {
        currentHealth += damage;
        Debug.Log("Current player health:" + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead. Game over.");
            SceneManager.LoadScene(sceneName: "GameOver");
        }
    }

}
