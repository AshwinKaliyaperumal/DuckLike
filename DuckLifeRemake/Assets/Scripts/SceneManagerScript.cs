using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    static string previousScene;
    static string currentScene;

    public void StartFlyingTraining()
    {
        ChangeScene("FlyingMinigame");
    }

    public void StartRunningTraining()
    {
        ChangeScene("RunningMinigame");
    }

    public void StartSwimmingTraining()
    {
        ChangeScene("SwimmingMinigame");
    }

    public void StartClimbingTraining()
    {
        ChangeScene("ClimbingMinigame");
    }

    public void LoseScreen()
    {
        ChangeScene("Lose");
    }

    public void WinScreen()
    {
        ChangeScene("Win");
    }

    public void QuitToHome()
    {
        ChangeScene("Home");
    }

    public void EnterCredits()
    {
        ChangeScene("Credits");
    }

    public void EnterRules()
    {
        ChangeScene("Rules");
    }

    public void StartFirstRace()
    {
        ChangeScene("First Race");
    }

    public void RestartCurrentScene()
    {
        ChangeScene(currentScene);
    }
    
    public void EnterShop()
    {
        ChangeScene("Shop");
    }

    public void PreviousScene()
    {
        if (previousScene != null)
        {
            ChangeScene(previousScene);
        }
    }

    public void SetScene(string scene)
    {
        ChangeScene(scene);
    }

    private void ChangeScene(string scene)
    {
        Debug.Log("previous scene: " + previousScene);
        Debug.Log("changing scene from: " + currentScene + " to: " + scene);
        previousScene = currentScene;
        currentScene = scene;
        SceneManager.LoadScene(currentScene);
    }
}
