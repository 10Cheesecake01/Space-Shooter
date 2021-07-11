using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Creating a enemy spwan radius around the player. 
    public GameObject enemyPrefab;
    float spawnDistance = 10f;
    float emenyRate = 5;
    float nextEnemy = 1;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0){
            nextEnemy = emenyRate;
            emenyRate *= 0.9f;
            if(emenyRate < 2){
                emenyRate = 2;
            }

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
