using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for score triggering in flying minigame
public class PointsTriggerScript : MonoBehaviour
{
    public ScoreManager Logic;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Logic.AddScore(1);
        }
    }
}
