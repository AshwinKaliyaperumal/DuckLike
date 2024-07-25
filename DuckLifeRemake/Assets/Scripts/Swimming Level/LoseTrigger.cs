using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public SceneManagerScript sceneManager;
    public UpdateStats stats;
    public string gameName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            GameOver();
            GameObject.Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag.Equals("Obstacle") || collision.gameObject.tag.Equals("Coin"))
        {
            GameObject.Destroy(collision.gameObject);
        }
    }

    public void GameOver()
    {
        stats.updateStats(gameName);
        sceneManager.LoseScreen();
    }
}
