using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // When the player is killed, the player respawn will certain amount of life left.
    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer;

    public int numLives = 4;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject) Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInstance == null && numLives > 0){
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0){
            SpawnPlayer();
            }
        }
    }

    void OnGUI()
    {
        if(numLives > 0 || playerInstance != null){
        GUI.Label( new Rect(0, 0, 100, 50), "Lives left: " + numLives);
        }
        else{
            GUI.Label( new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 50), "Game Over!");
        }
    }
}
