using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuckClimbScript : MonoBehaviour
{
    // Start is called before the first frame update
    public enum DuckClimbState
    {
        None,
        Moving,
        OnWall
    }

    public float Speed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public DuckClimbState climbState = DuckClimbState.None;
    public GameObject Character;
    public GameObject RockWall1;
    public GameObject RockWall2;
    public ScoreManager scoreManager;
    private bool movingRight;
    [SerializeField] private AudioClip jumpSoundClip;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * Speed;
        climbState = DuckClimbState.OnWall;
        scoreManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreManager>();
    }

    // Update is called once per frame

    void Update()
    {
        if(climbState == DuckClimbState.OnWall) 
        {
            float vert = Input.GetAxis("Vertical") * Speed;
            Character.transform.Translate(0, vert * Time.deltaTime, 0);

            if(Input.GetKey("a")) 
            {
                climbState = DuckClimbState.Moving;
                movingRight = false;
                sprite.flipX = true;
                SoundManager.instance.PlaySoundClip(jumpSoundClip, 1f);
            }
            else if(Input.GetKey("d")) 
            {
                climbState = DuckClimbState.Moving;
                movingRight = true;
                sprite.flipX = false;
                SoundManager.instance.PlaySoundClip(jumpSoundClip, 1f);
            }
        }

        if (climbState == DuckClimbState.Moving) 
        {
            if(movingRight) 
            {
                rb.velocity = Vector3.right * Speed;
            }
            else 
            {
                rb.velocity = Vector3.left * Speed;
            }
            
        } 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.name == "RockWall1") || (other.gameObject.name == "RockWall2")) 
        {
            climbState = DuckClimbState.OnWall;
        }
    }
}
