using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;

    public bool isBoss = false;

    public float spawnInterval;
    private float nextSpawn;

    public int miniEnemySpawnCount;

    private SpawnManager spawnManager;

    void  Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (isBoss)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * speed);
        if (isBoss)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnInterval;
                spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
            }
        }
        
            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }
      
    }
}