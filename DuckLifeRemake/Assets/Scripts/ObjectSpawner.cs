using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is an abstract class meant to serve as an outline for object spawning
 * 
 * Includes rough implementation for:
 *      - update method
 * 
 * Includes abstract methods for:
 *      - start method
 *      - actual object spawning procedure
 *      - determining spawn rate
 * 
 */

public abstract class ObjectSpawner : MonoBehaviour
{
    public float timer = 0;
    public float spawnRate { get; set; }

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObject();
            timer = 0;
        }
    }

    public abstract void SpawnObject();

    public abstract void UpdateSpawnRate();
}
