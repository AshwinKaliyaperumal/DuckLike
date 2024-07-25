using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour
{
    public Stats stats = DuckStatScript.stats;
    public int minInclusive;
    public int maxExclusive;
    public LevelSystem levelSystem;
    
    void Awake()
    {
         levelSystem = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelSystem>();
    }

    public void resetStats() {
        stats.running = Random.Range(minInclusive, maxExclusive);
        stats.swimming = Random.Range(minInclusive, maxExclusive);
        stats.climbing = Random.Range(minInclusive, maxExclusive);
        stats.flying = Random.Range(minInclusive, maxExclusive);
        stats.stamina = 0;
        stats.requiredRunningXp = levelSystem.CalculateRequiredXp(stats.running);
        stats.requiredSwimmingXp = levelSystem.CalculateRequiredXp(stats.swimming);
        stats.requiredClimbingXp = levelSystem.CalculateRequiredXp(stats.climbing);
        stats.requiredFlyingXp = levelSystem.CalculateRequiredXp(stats.flying);
    }
}
