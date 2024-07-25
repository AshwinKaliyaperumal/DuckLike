using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class CoinSpawner : ObjectSpawner
{
    private GameObject coinPrefab;

    [Header("Coin Spawning")]
    public bool horizontalScrolling = true;
    public float coinOffset = 10;
    public float baseSpeed = 5f;

    // Start is called before the first frame update
    public override void Start()
    {
        coinPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Coin.prefab", typeof(GameObject));
        spawnRate = 2f;
    }

    public override void SpawnObject()
    {
        float offset = Random.Range(-coinOffset, coinOffset);
        GameObject coin;

        if (horizontalScrolling)
        {
            coin = GameObject.Instantiate(coinPrefab, this.transform.position + Vector3.up * offset, Quaternion.identity);
        }
        else
        {
            coin = GameObject.Instantiate(coinPrefab, this.transform.position + Vector3.left * offset, Quaternion.identity);
        }

        coin.GetComponent<CoinScript>().IsHorizontal = horizontalScrolling;
        CoinScript.MoveSpeed = baseSpeed;
    }

    public override void UpdateSpawnRate()
    {
        // spawn rate changes based on specific minigame implementation
    }
}
