using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
CITATION: Some of the following code was adapted from this tutorial: https://youtu.be/XtQMytORBmM?si=UzEmA6PbbUV4uFn6
*/

public class PipeScript : MonoBehaviour
{
    public static float MoveSpeed;
    public float DeadZone = -40;
    public float SpawnZone = 7;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;

        if (transform.position.x < DeadZone) {
            Destroy(gameObject);
        }
    }
}
