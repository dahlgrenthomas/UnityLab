using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform spawnLocation;
    private float secondsPerSpawn = 5;
    private float lastSpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(secondsPerSpawn > .5f)
        {
            secondsPerSpawn -= (0.05f * Time.deltaTime);
        }
        
        if (Time.time - lastSpawnTime >= secondsPerSpawn && FPSPlayer.instance.ShouldSpawn(spawnLocation.position))
        {
            lastSpawnTime = Time.time;
            Spawn();
        }

    }
    private void Spawn()
    {
        GameObject enemyPrefab = enemies[Random.Range(0, enemies.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = spawnLocation.position;
    }
}
