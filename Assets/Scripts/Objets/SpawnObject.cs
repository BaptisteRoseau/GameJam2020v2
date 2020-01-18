using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float spawnTimeMin = 3.0f;  // Minimum spawn time in seconds seconds
    public float spawnTimeMax = 5.0f;  // Maximum spawn time in seconds seconds
    public GameObject[] objects;       // Object to be spawned
    public Transform[] spawnPoints;


    // Similar to InvokeRepeating but with a random wait between minTime and maxTime
    public delegate void MethodToCall(); //A delegate - you can pass in any method with the signature void xxx() in this case!
    public IEnumerator InvokeRepeatingRange(MethodToCall method, float timeUntilStart, float minTime, float maxTime)
    {
        yield return new WaitForSeconds(timeUntilStart);
        while (true)
        {
            method(); //This calls the method you passed in
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeatingRange(SpawnObject, 0.0f, spawnTimeMin, spawnTimeMax);
    }

    // Spawns random object from the "objects" list at the "spawnPoints" position
    void SpawnObject()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int objectIndex = Random.Range(0, objects.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(objects[objectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
