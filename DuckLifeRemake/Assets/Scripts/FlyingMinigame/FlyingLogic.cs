using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

/*
 * This is a class meant to serve as the flying minigame's logic system
 */

/*
CITATION: Some of the following code was adapted from this tutorial: https://youtu.be/XtQMytORBmM?si=UzEmA6PbbUV4uFn6
*/

public class FlyingLogic : LogicManager
{
    public UpdateStats stats;

    // default values for flying
    public static readonly float DEFAULT_MOVE_SPEED = 5;
    public static readonly float DEFAULT_SPAWN_RATE = 2;

    // fields for object movement with default values
    [Header("Object Movement")]
    public float moveSpeed = DEFAULT_MOVE_SPEED;
    public float acceleration = 1;
    public float accelerationRate = 5;
    private static float speedTimer = 0;

    void Start()
    {
    }

    public override void Update()
    {
        // calculate move speed of obstacles based on how long the player lasts
        UpdateMoveSpeed();

        // update move speed of obstacle scripts
        UpdateScripts();
    }

    public new void Restart()
    {
        base.Restart();
        PipeScript.MoveSpeed = 5;
    }

    public override void GameOver()
    {
        stats.updateStats("Flying");
        sceneManager.LoseScreen();
    }

    private void UpdateMoveSpeed()
    {
        if (speedTimer >= accelerationRate)
        {
            moveSpeed += acceleration;
            speedTimer = 0;
        }
        speedTimer += Time.deltaTime;
    }

    private void UpdateScripts()
    {
        PipeScript.MoveSpeed = moveSpeed;
        CoinScript.MoveSpeed = moveSpeed;
    }
}
