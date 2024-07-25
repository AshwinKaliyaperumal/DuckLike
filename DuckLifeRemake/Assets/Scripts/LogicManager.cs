using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * This is an abstract class meant to serve as an outline for minigame logic
 * 
 * Includes rough implementation for:
 *      - player score tracking/changing & display
 *      - restarting the game/current scene
 * 
 * Includes abstract methods for:
 *      - game over condition
 *      - frame updates
 * 
 */


public abstract class LogicManager : MonoBehaviour
{
    // minimum elements for a logic manager
    public int playerScore;
    public TMP_Text scoreText;
    public SceneManagerScript sceneManager;

    // add score method
    public void AddScore(int toAdd)
    {
        playerScore += toAdd;
        scoreText.text = playerScore.ToString();
    }

    // restart game method
    public void Restart()
    {
        sceneManager.RestartCurrentScene();
    }

    // game over method - will be implemented differently for each minigame
    public abstract void GameOver();

    // update method - will be implemented differently for each minigame
    public abstract void Update();
}
