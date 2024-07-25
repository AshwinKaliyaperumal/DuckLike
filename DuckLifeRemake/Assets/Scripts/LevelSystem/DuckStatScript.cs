using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckStatScript : MonoBehaviour
{
    public static Stats stats = new Stats();
    public int minInclusive;
    public int maxExclusive;
    public LevelSystem levelSystem;
    // Start is called before the first frame update
    void Awake()
    {
         levelSystem = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelSystem>();
    }
    void Start()
    {
        if(stats.running == 0) {
            stats.running = Random.Range(minInclusive, maxExclusive);
            stats.swimming = Random.Range(minInclusive, maxExclusive);
            stats.climbing = Random.Range(minInclusive, maxExclusive);
            stats.flying = Random.Range(minInclusive, maxExclusive);
            stats.stamina = 0;
        }
        stats.requiredRunningXp = levelSystem.CalculateRequiredXp(stats.running);
        stats.requiredSwimmingXp = levelSystem.CalculateRequiredXp(stats.swimming);
        stats.requiredClimbingXp = levelSystem.CalculateRequiredXp(stats.climbing);
        stats.requiredFlyingXp = levelSystem.CalculateRequiredXp(stats.flying);
    }

    void Update() {
        
    }
}