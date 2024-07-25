using UnityEngine;
using TMPro;

public class StaminaStat : MonoBehaviour
{
    public TMP_Text statDisplay;
    public Stats stats = DuckStatScript.stats;
    void Update()
    {
        statDisplay.text = "Stamina: " + stats.stamina;
    }
    private void Start()
    {
        HomeDuckBehavior.foodEaten += IncreaseStamina;
    }

    public void IncreaseStamina(GameObject food)
    {
        if (food.name.Contains("Good Food"))
        {
            stats.stamina += 2;
        }
        else
        {
            stats.stamina++;
        }
    }
}
