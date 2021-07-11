using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // We want the player to shoot at the enemy ship.
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    int bulletLayer;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }


    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset; 
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
