using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private CapsuleCollider2D myCollider;
    public float flapStrength;
    public float speed;
    public bool birdIsAlive = true;
    [SerializeField] private AudioClip jumpSoundClip;

    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true && IsGrounded()) {   // jump
            myRigidbody.velocity = Vector2.up * flapStrength;
            SoundManager.instance.PlaySoundClip(jumpSoundClip, 1f);
        }

        if (Input.GetKey(KeyCode.D) == true && birdIsAlive == true) {   // move right
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y); 
        }

        if (Input.GetKey(KeyCode.A) == true && birdIsAlive == true) {   // move left
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        return Physics2D.Raycast(transform.position, Vector2.down, myCollider.bounds.extents.y + 0.1f, mask);
    }
}
