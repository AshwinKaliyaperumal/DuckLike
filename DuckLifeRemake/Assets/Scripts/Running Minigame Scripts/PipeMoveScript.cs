using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float pipeDeadZone = -45;
    public ScoreManager logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime * logicScript.score;

        if (transform.position.x < pipeDeadZone) 
        {
            Destroy(gameObject);
        }
    }
}
