using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDuckBehavior : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private SpriteRenderer mySprite;

    public Vector2 jumpStrength = new Vector2(5f, 5f);
    private bool isFacingRight = true;

    private bool isEating = false;
    public GameObject foodLocation;
    private float eatingRange = 3f;
    private GameObject target;

    private float eatCD = 1f;
    private float timer = 0;

    public delegate void FoodEaten(GameObject other);
    public static event FoodEaten foodEaten;

    private void Awake()
    {
        foodEaten = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        timer = eatCD;
    }

    // Update is called once per frame
    void Update()
    {
        if(foodLocation.transform.childCount > 0)
        {
            isEating = true;
        } 
        else
        {
            isEating = false;
        }

        if(!isEating)
        {
            Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isFacingRight = worldMousePos.x > transform.position.x;
            timer = eatCD;
        } 
        else
        {
            target = GetClosestFood();
            timer += Time.deltaTime;
            Debug.Log(target.name);

            isFacingRight = foodLocation.transform.position.x > transform.position.x;
            
            if(target != null && Vector2.Distance(transform.position, target.transform.position) < eatingRange && timer >= eatCD) 
            {
                Debug.Log("eat");
                //start eating animation
                if (foodEaten != null)
                {
                    Debug.Log("called");
                    foodEaten.Invoke(target);
                
                }

                GameObject.Destroy(target);
                timer = 0;
            }
        }

        if (IsGrounded())
        {
            if (isFacingRight)
            {
                myRigidbody.velocity = jumpStrength;
                mySprite.flipX = false;
            }
            else
            {
                myRigidbody.velocity = jumpStrength * new Vector2(-1, 1);
                mySprite.flipX = true;
            }
        }
    }

    private GameObject GetClosestFood()
    {
        Transform closest = foodLocation.transform.GetChild(0);

        for(int i = 1; i < foodLocation.transform.childCount; i++)
        {
            if(GetDistance(foodLocation.transform.GetChild(i)) < GetDistance(closest)) 
            {
                closest = foodLocation.transform.GetChild(i);
            } 
        }

        return closest.gameObject;
    }

    private float GetDistance(Transform other)
    {
        return Mathf.Abs(transform.position.x - other.position.x);
    }

    private bool IsGrounded() 
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        return Physics2D.Raycast(transform.position, Vector2.down, myCollider.bounds.extents.y + 0.1f, mask);
    }
}
