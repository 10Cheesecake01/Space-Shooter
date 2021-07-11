using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float invunPeriod = 0;
    public int health = 1;
    float invuln = 0;

    int correctLayer;
    SpriteRenderer spriteRend;

    // Switching between different layers.
    void Start(){  
        correctLayer = gameObject.layer;

        spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
        }

        if(spriteRend == null)
        {
            Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
        }
            
    }

    // When the player collides with the enemy, player health decreases and gets 1 second of invulnerablility.
    void OnTriggerEnter2D(){  
        
        health--;
        invuln = invunPeriod;

        gameObject.layer = 8;
        
    }

    // Checking for invulnerablility condition.
    void Update(){  

       if(invuln > 0)
        {
        invuln -= Time.deltaTime;
        }

        if(invuln <= 0)
        {
            gameObject.layer = correctLayer;
            
        }

        if(spriteRend != null)
        {
            spriteRend.enabled = true;
        }
        else
        {
            if(spriteRend != null)
        {
            spriteRend.enabled = !spriteRend.enabled;
        }
        }

        if(health <= 0)
        {
            Die();
        }
    }

    // Kills the player.
    void Die(){ 
        Destroy(gameObject);
    }
}
