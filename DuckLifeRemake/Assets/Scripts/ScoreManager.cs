using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text coinDisplay;

    public TMP_Text scoreDisplay;
    public float score = 0;
    public bool timeBased = false;

    // Update is called once per frame
    void Update()
    {
        if(timeBased) {
            score += Time.deltaTime;
            scoreDisplay.text = ((int)score).ToString();
        }

        coinDisplay.text = CoinManager.incomingBalance.ToString();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int moreScore)
    {
        score += moreScore;
        scoreDisplay.text = ((int)score).ToString();
    }

    public int returnScore() 
    {
        return (int) score;
    }
}
