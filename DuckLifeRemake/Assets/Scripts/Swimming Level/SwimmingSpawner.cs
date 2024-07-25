using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingSpawner : ObjectSpawner
{
    public GameObject[] obstacleList;
    public float timeBeforeIncrease = 5f;
    public float speedIncrement = 0.1f;
    private float difficultyTimer = 0f;

    public CoinSpawner coinSpawner;

    // Start is called before the first frame update
    public override void Start()
    {
        difficultyTimer = timeBeforeIncrease;
        SwimmingObstacle.moveSpeed = 5;
        spawnRate = 5f;
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
        int randNum = Random.Range(0, obstacleList.Length);
        Vector3 offset = Vector3.zero;

        if(obstacleList[randNum].name.Contains("Island"))
        {
            offset += new Vector3(0, -0.472f, 0);
        }
        else if(obstacleList[randNum].name.Contains("Ship"))
        {
            offset += new Vector3(0, 1.67f, 0);
        }

        GameObject.Instantiate(obstacleList[randNum], this.transform.position + offset, Quaternion.identity);
    }

    public override void UpdateSpawnRate()
    {
        if (difficultyTimer <= 0)
        {
            SwimmingObstacle.moveSpeed += speedIncrement;
            coinSpawner.baseSpeed += speedIncrement;
            spawnRate *= 1 - speedIncrement;

            difficultyTimer = timeBeforeIncrease;
        }
        else
        {
            difficultyTimer -= Time.deltaTime;
        }
    }
}
