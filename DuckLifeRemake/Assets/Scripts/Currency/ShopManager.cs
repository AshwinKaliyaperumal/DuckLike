using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TMP_Text balanceDisplay;

    private void Start()
    {
        if(balanceDisplay)
        {
            UpdateDisplay();
        }
    }

    // updates text to show player's current balance
    private void UpdateDisplay()
    {
        balanceDisplay.text = CoinManager.GetBalance().ToString();
    }

    // given a ShopItem, updates the player's balance if they can afford it
    public void BuyItem(ShopItem item)
    {
        if(CoinManager.GetBalance() >= int.Parse(item.price.text))
        {
            CoinManager.RemoveCoins(int.Parse(item.price.text));
            UpdateDisplay();
        }

        switch(item.type)
        {
            case ItemType.Food:
                FoodManager.foodBought++;
                break;
            case ItemType.BetterFood:
                FoodManager.betterFoodBought++;
                break;
            case ItemType.Clothing:
                break;
            default:
                break;
        }
    }
}
