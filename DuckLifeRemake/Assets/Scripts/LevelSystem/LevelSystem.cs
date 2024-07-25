using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public Stats stats = DuckStatScript.stats;

    [Range(1f,300f)]
    public float additionMultiplier = 300;
    [Range(2f,4f)]
    public float powerMultiplier = 2;
    [Range(7f,14f)]
    public float divisionMultiplier = 7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainExperience(float xpGained, string minigame) {
        if(minigame == "Flying") {
            stats.currentFlyingXp += xpGained;
            if(stats.currentFlyingXp > stats.requiredFlyingXp) {
                stats.currentFlyingXp -= stats.requiredFlyingXp;
                stats.flying++;
                stats.requiredFlyingXp = CalculateRequiredXp(stats.flying);
            }
        }
        else if(minigame == "Running") {
            stats.currentRunningXp += xpGained;
            if(stats.currentRunningXp > stats.requiredRunningXp) {
                stats.currentRunningXp -= stats.requiredRunningXp;
                stats.running++;
                stats.requiredRunningXp = CalculateRequiredXp(stats.running);
            }
        }
        else if(minigame == "Climbing") {
            stats.currentClimbingXp += xpGained;
            if(stats.currentClimbingXp > stats.requiredClimbingXp) {
                stats.currentClimbingXp -= stats.requiredClimbingXp;
                stats.climbing++;
                stats.requiredClimbingXp = CalculateRequiredXp(stats.climbing);
            }
        }
        else if(minigame == "Swimming") {
            stats.currentSwimmingXp += xpGained;
            if(stats.currentSwimmingXp > stats.requiredSwimmingXp) {
                stats.currentSwimmingXp -= stats.requiredSwimmingXp;
                stats.swimming++;
                stats.requiredSwimmingXp = CalculateRequiredXp(stats.swimming);
            }
        }
    }

    public int CalculateRequiredXp(int currentLevel) {
        int solveForRequiredXp = 0;
        if(currentLevel<5) {
            for(int levelCycle = 1; levelCycle <= currentLevel; levelCycle++) {
                solveForRequiredXp += levelCycle*5;
            }
            return solveForRequiredXp;
        }
        for(int levelCycle = 1; levelCycle <= currentLevel; levelCycle++) {
            solveForRequiredXp += (int) Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
 