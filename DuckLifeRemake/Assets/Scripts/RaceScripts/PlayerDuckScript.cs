using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuckScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Stats stats = DuckStatScript.stats;
    private int DuckState = 0; // 0 - running, 1 - swimming, 2 - climbing, 3 - flying

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int RunningStat = stats.running;
        Debug.Log(stats.running);
        int FlyingStat = stats.flying;
        int ClimbingStat = stats.climbing;
        int SwimmingStat = stats.swimming;

        if (DuckState == 0) 
        {
            myRigidbody.velocity = Vector2.right * RunningStat; 
        } 
        else if (DuckState == 1) 
        {
            myRigidbody.velocity = Vector2.right * SwimmingStat; 
        }
        else if (DuckState == 2) 
        {
            myRigidbody.velocity = Vector2.right * RunningStat;
            myRigidbody.velocity = Vector2.up * ClimbingStat; 
        }
        else if (DuckState == 3) 
        {
            myRigidbody.velocity = Vector2.right * FlyingStat;
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.name == "Land1" || other.gameObject.name == "Land2") 
        {
            DuckState = 0;
        } 
        else if (other.gameObject.name == "Water") 
        {
            DuckState = 1;
        }
        else if (other.gameObject.name == "Cliff") 
        {
            DuckState = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        DuckState = 3;    
    }
}
