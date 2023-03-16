using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start er kallað fyrir fyrstu ramma
    void Start()
    {
        // Endurkalla SpawnRandomAnimal fallið á hverjum tíma sem startDelay segir og á milli hvers langt spawnInterval er
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        // Velja slembin index úr animalPrefabs
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // Búa til slembnar x, y og z gildi fyrir staðsetningu
        Vector3 spawnPos = new Vector3 (Random.Range (-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // Búa til afrit af animalPrefabs[animalIndex] í slembnu staðsetningu og snúningi sem hluturinn á
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

}
