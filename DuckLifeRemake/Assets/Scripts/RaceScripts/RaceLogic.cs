using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceLogic : MonoBehaviour
{
    public int duckSpeed = 5;
    public int npcSpeed = 4;
    public int raceDuration = 10;

    // simulates a race with the above fields
    // loads win/lose screen based on duck's result
    public void Race() {
        int duckDist = duckSpeed * raceDuration;
        int npcDist = npcSpeed * raceDuration;
        
        if (duckDist >= npcDist) // if the duck wins or ties, load win screen
        {
            SceneManager.LoadScene("Win");
        }
        else    // if the npc wins, load lose screen
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
