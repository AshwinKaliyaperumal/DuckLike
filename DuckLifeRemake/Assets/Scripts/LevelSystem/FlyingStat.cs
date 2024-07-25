using UnityEngine;
using TMPro;

public class FlyingStat : MonoBehaviour
{
    public TMP_Text statDisplay;
    public Stats stats = DuckStatScript.stats;
    void Update()
    {
        statDisplay.text = ""+stats.flying;
    }
}
