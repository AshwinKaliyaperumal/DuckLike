using UnityEngine;
using TMPro;

public class RunningStat : MonoBehaviour
{
    public TMP_Text statDisplay;
    public Stats stats = DuckStatScript.stats;
    void Update()
    {
        statDisplay.text = ""+stats.running;
    }
}
