using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStats : MonoBehaviour
{
    public Stats stats = DuckStatScript.stats;
    public ScoreManager scoreManager;
    public static LevelSystem levelSystem = new LevelSystem();

    public void Awake() {
        scoreManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreManager>();
    }

    public void updateStats(string minigame) {

        // some things got messed up with the coin management, so I (Brenda)
        // temporarily put it here because all the minigames use this
        CoinManager.AddIncoming();

        int score = scoreManager.returnScore();

        if(minigame == "Flying") {
            levelSystem.GainExperience(score, "Flying");
        }
        else if(minigame == "Running") {
            levelSystem.GainExperience(score, "Running");
        }
        else if(minigame == "Climbing") {
            levelSystem.GainExperience(score, "Climbing");
        }
        else if(minigame == "Swimming") {
            levelSystem.GainExperience(score, "Swimming");
        }
    }
}