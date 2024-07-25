using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningSpawner : ObjectSpawner
{
    // prefabs for instantiation
    public GameObject SmallRock;
    public GameObject LongRock;
    public GameObject TallRock;

    public Transform groundLevel;

    public ScoreManager logicScript;

    // Start is called before the first frame update
    public override void Start()
    {
        SpawnObject();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreManager>();
        UpdateSpawnRate();
    }

    // Update is called once per frame
    public new void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObject();
            logicScript.AddScore(1); // QUESTION: WHY DO WE INCREASE SCORE WHEN WE SPAWN A NEW OBJECT?
            UpdateSpawnRate();
            timer = 0;
        }
    }

    public override void SpawnObject()
    {
        // using a random number generator, pick one of the three rock types to spawn
        float random = Random.Range(0, 3);
        if (random == 0)
        {
            Instantiate(SmallRock, new Vector3(transform.position.x, CalculateSpawnHeight(SmallRock), 0), transform.rotation);
        }
        else if (random == 1)
        {
            Instantiate(LongRock, new Vector3(transform.position.x, CalculateSpawnHeight(LongRock), 0), transform.rotation);
        }
        else
        {
            Instantiate(TallRock, new Vector3(transform.position.x, CalculateSpawnHeight(TallRock), 0), transform.rotation);
        }
    }

    private float CalculateSpawnHeight(GameObject rock)
    {
        Transform anchor = rock.transform.GetChild(0);
        return groundLevel.position.y - anchor.position.y;
    }

    public override void UpdateSpawnRate()
    {
        spawnRate = Random.Range(5, 15);
    }
} 
