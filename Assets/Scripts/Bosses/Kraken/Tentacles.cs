using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacles : MonoBehaviour
{
    [SerializeField] GameObject tentacle;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;

    [SerializeField] float spawnCooldown = 20f;

    [SerializeField] float maxTimer = 10f;
    float timer;
    float minTimer = 0f;

    Animator animator;

    void Start()
    {
        animator = tentacle.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (timer <= minTimer)
        {
            timer = maxTimer;
            SpawnTentacle();
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    void SpawnTentacle()
    {
        Instantiate(tentacle, spawnPoint1);
        Instantiate(tentacle, spawnPoint2);
        Debug.Log("Tentacle prefab has been instantiated.");
        StartCoroutine(SpawnTentacleWait());
    }

    protected IEnumerator SpawnTentacleWait()
    {
        yield return new WaitForSeconds(spawnCooldown);
    }
}