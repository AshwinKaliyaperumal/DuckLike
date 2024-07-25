using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
CITATION: Some of the following code was adapted from this tutorial: https://youtu.be/XtQMytORBmM?si=UzEmA6PbbUV4uFn6
*/

public class FlyingDuckScript : MonoBehaviour
{
    public Rigidbody2D DuckRB;
    public int FlapStrength;
    public FlyingLogic Logic;
    public bool IsAlive = true;
    private float _gravityScaleDefault = 4.5F;
    public TMP_Text IntroInstructions;
    [SerializeField] private AudioClip flapSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<FlyingLogic>();

        // pause all game movement until key is pressed
        DuckRB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsAlive) // duck flaps
        {
            IntroInstructions.gameObject.SetActive(false) ;
            DuckRB.gravityScale = _gravityScaleDefault;
            DuckRB.velocity = Vector2.up * FlapStrength;
            SoundManager.instance.PlaySoundClip(flapSoundClip, 1f);
        }
    }

    private void GameOver()
    {
        Logic.GameOver();
        IsAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("on collision 2d");
        Debug.Log("pipe collision");
        // player dies
        GameOver();
    }
}
