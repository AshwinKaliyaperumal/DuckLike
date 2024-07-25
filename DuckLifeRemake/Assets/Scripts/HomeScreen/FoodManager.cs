using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class FoodManager : MonoBehaviour
{
    [Header("Food Stuff")]
    public static int currFoodCount;
    public static int foodBought;
    public static int betterFoodBought;

    public Transform foodSpawnPoint;

    public GameObject foodPrefab;
    public GameObject betterFoodPrefab;

    public float spawnRate = 0.5f;
    private float timer = 0f;

    [Header("Money Stuff")]
    public TMP_Text balanceDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(currFoodCount > foodBought)
        {
            foodBought = currFoodCount;
        }
        else
        {
            currFoodCount = foodBought;
        }

        // updates display to current balance
        balanceDisplay.text = CoinManager.GetBalance().ToString();
        timer = spawnRate;
        HomeDuckBehavior.foodEaten += UpdateFoodCount;
    }

    private void Update()
    {
        if(foodBought > 0 || betterFoodBought > 0)
        {
            if (timer <= 0)
            {
                if(foodBought > 0)
                {
                    GameObject.Instantiate(foodPrefab, foodSpawnPoint.position, Quaternion.identity, foodSpawnPoint);
                    foodBought--;
                    timer = spawnRate;
                }
                else if (betterFoodBought > 0)
                {
                    GameObject.Instantiate(betterFoodPrefab, foodSpawnPoint.position, Quaternion.identity, foodSpawnPoint);
                    betterFoodBought--;
                    timer = spawnRate;
                }

            }
            else
            {
                timer -= Time.deltaTime;
            }
        } 
    }
    
    private void UpdateFoodCount(GameObject other)
    {
        currFoodCount--;
    }
}
