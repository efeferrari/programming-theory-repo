using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowBall()
    {
        Vector3 firstObstaclePosition = GameObject.Find("FirstObstacle").transform.position;

        // Calculate ball trajectory.
    }
}
