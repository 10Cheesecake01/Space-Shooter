using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacesPlayer : MonoBehaviour
{
    // We want the enemy to find and kill the player.
    public float rotSpeed = 180f;
    Transform player;

    // Update is called once per frame
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

        // Either the player is not found or doesn't exist.

        if (player == null)
        {
            return; // Try again in the next frame. 
        }

        // Here we know for a fact that the player is alive.

        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);       
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
