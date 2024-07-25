using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingObstacle : MonoBehaviour
{
    public static float moveSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
