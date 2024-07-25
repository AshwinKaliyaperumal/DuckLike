using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingSpawner : ObjectSpawner
{
    // prefabs for instantiation
    public GameObject SmallRock;
    public GameObject LongRock;

    public float low;
    public float high;

    // Start is called before the first frame update
    public override void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    public new void Update()
    {
        UpdateSpawnRate();
        base.Update();
    }

    public override void SpawnObject() 
    {
        // using a random number generator, pick one of the two rock types to spawn
        float random = Random.Range(0, 2);
        if (random == 0)
        {
            Instantiate(SmallRock, transform.position, transform.rotation);
        } else if (random == 1)
        {
            Instantiate(LongRock, transform.position, transform.rotation);
        }
    }

    public override void UpdateSpawnRate()
    {
        spawnRate = Random.Range(low, high);
    }
}
