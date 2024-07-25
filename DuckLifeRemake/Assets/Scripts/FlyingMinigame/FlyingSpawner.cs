using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/*
CITATION: Some of the following code was adapted from this tutorial: https://youtu.be/XtQMytORBmM?si=UzEmA6PbbUV4uFn6
*/

public class FlyingSpawner : ObjectSpawner
{
    // fields for pipe spawning
    public GameObject PipePrefab;
    public float HeightOffset = 10;

    // Start is called before the first frame update
    public override void Start()
    {
        spawnRate = 2;
        SpawnObject();
    }

    public override void SpawnObject()
    {
        float lowestPoint = transform.position.y - HeightOffset;
        float highestPoint = transform.position.y + HeightOffset;

        Instantiate(PipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    public override void UpdateSpawnRate()
    {
        throw new System.NotImplementedException();
    }
}
