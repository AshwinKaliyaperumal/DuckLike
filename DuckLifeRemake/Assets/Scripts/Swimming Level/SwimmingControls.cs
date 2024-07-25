using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingControls : MonoBehaviour
{
    [Header("Swim Settings")]
    public float speed = 3f;
    public float swimForce = 3f;
    public float maxTime = 0.05f;

    [Header("Range")]
    public float maxHeight;
    public float minHeight;

    private float timer = 0f;
    private bool canDive = true;

    public Rigidbody2D myRb;

    [SerializeField] private AudioClip splashSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();

        Renderer renderer = gameObject.GetComponent<Renderer>();
        float height = renderer.bounds.size.y;

        // setting the max/min height for diving to be when the player is at water level
        maxHeight = transform.position.y + height;
        minHeight = transform.position.y - height;
    }

    // Update is called once per frame
    private void Update()
    {
        // left and right movement
        if(Input.GetKey(KeyCode.RightArrow))
        {
            myRb.velocity = new Vector2(speed, myRb.velocity.y);
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRb.velocity = new Vector2(-speed, myRb.velocity.y);
        }

        // only let player dive/jump when at water level
        if (transform.position.y <= maxHeight && transform.position.y >= minHeight)
        {
            canDive = true;
        }
        else
        {
            canDive = false;
        }

        // up and down movement
        if (Input.GetKeyDown(KeyCode.DownArrow) && canDive)
        {
            myRb.AddForce(new Vector2(0, -swimForce * 2) * Time.deltaTime, ForceMode2D.Impulse);
            timer = maxTime;
            SoundManager.instance.PlaySoundClip(splashSoundClip, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && canDive)
        {
            myRb.AddForce(new Vector2(0, swimForce) * Time.deltaTime, ForceMode2D.Impulse);
            timer = maxTime;
        }

        // only let player go up/down for certain period of time (longer they hold it, the further they go)
        if(timer > 0)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myRb.AddForce(new Vector2(0, -swimForce * 2) * Time.deltaTime, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myRb.AddForce(new Vector2(0, swimForce) * Time.deltaTime, ForceMode2D.Impulse);
            }

            timer -= Time.deltaTime;
        } 
    }
}
