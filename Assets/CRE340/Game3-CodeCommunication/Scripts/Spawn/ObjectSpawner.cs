using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random; // Import for using Lists

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;  // Array of prefabs to spawn
    
    public Vector3 spawnArea;           // x, y, z (width, height, depth) of the spawn area
    public float minSpawnInterval = 2f; // Minimum spawn interval (2 seconds)
    public float maxSpawnInterval = 5f; // Maximum spawn interval (5 seconds)
    
    public List<GameObject> spawnedObjects = new List<GameObject>();
    void Start()
    {
        // Start invoking the SpawnObject method at a random interval
        InvokeRepeating("SpawnRandomObject", Random.Range(minSpawnInterval, maxSpawnInterval), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnRandomObject()
    {
        if (objectPrefabs.Length == 0) return;  // Ensure there is something to spawn

        // Pick a random prefab from the array
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject prefabToSpawn = objectPrefabs[randomIndex];

        // Generate a random position within the spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(0, spawnArea.y),
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        // Instantiate the prefab at the random position
        GameObject spawnedObject = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        
        spawnedObjects.Add(spawnedObject);

        // Reschedule the next spawn with a new random interval
        CancelInvoke("SpawnRandomObject"); // Cancel the current schedule
        Invoke("SpawnRandomObject", Random.Range(minSpawnInterval, maxSpawnInterval)); // Schedule the next spawn
    }

    // Method to visualize the spawn area in the Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
    
    public void ShowSpawnedObjectsCount()
    {
        Debug.Log("Number of spawned objects: " + spawnedObjects.Count);
    }
}
