using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacles : MonoBehaviour
{
    [SerializeField] Transform[] teleport;
    [SerializeField] GameObject tentacle;
    [SerializeField] float spawnCooldown = 5f;
    bool spawnTentacle = true;

    void Start()
    {
        int spawn = Random.Range(0, 7);
    }

    void FixedUpdate()
    {
        if (spawnTentacle)
        {
            //foreach (int x in Random.Range(1, 3))
            //{
                //SpawnTentacle();
            //}
            spawnTentacle = false;
            StartCoroutine(SpawnTentacleWait());
        }
    }

    void SpawnTentacle()
    {
        //Instantiate(tentacle, teleport[spawn].position);
    }

    protected IEnumerator SpawnTentacleWait()
    {
        yield return new WaitForSeconds(spawnCooldown);
        spawnTentacle = true;
    }
}