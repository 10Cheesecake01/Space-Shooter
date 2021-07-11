using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Enemy shoots with cool down at the player and the bullet should fire in-between the enemy ship.
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    int bulletLayer;
    public float fireDelay = 0.50f;
    float cooldownTimer = 0;
    Transform player;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.FindWithTag ("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4)
        {
            Debug.Log("Phew!!");
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset; 
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
