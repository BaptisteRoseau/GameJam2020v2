using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public float spawnTimeMin = 3.0f;  // Minimum spawn time in seconds seconds
    public float spawnTimeMax = 5.0f;  // Maximum spawn time in seconds seconds
    public GameObject[] objects;       // Object to be spawned
    public Transform[] spawnPoints;

    public float duplicateOffsetX = 0.0f;
    public float duplicateOffsetY = 0.0f;
    public bool duplicate = false;

    private float nextCall = 0.0f;

    private void Update()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        while (Time.realtimeSinceStartup > nextCall)
        {
            Debug.Log("Called");
            SpawnObject(); //This calls the method you passed in
            nextCall = Time.realtimeSinceStartup + Random.Range(spawnTimeMin, spawnTimeMax);
        }
    }

    // Spawns random object from the "objects" list at the "spawnPoints" position
    void SpawnObject()
    {
        Debug.Log("Spawned");
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int objectIndex = Random.Range(0, objects.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(objects[objectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        if (duplicate)
            Instantiate(objects[objectIndex], spawnPoints[spawnPointIndex].position + new Vector3(duplicateOffsetX, duplicateOffsetY, 0.0f), spawnPoints[spawnPointIndex].rotation);
    }
}
