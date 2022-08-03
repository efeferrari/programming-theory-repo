using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    GameManager GM;
    GameObject ball;
    GameObject firstObstacle;
    Rigidbody ballRb;

    void Start()
    {
        GM = GameManager.Instance;
        ball = GameObject.Find("Ball");
        firstObstacle = GameObject.Find("FirstObstacle");
        ballRb = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // @todo: Remove the false condition an check for spacebar action.
        if (!GM.IsGameOver && GM.CanThrow() && false)
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        Vector3 firstObstaclePosition = GameObject.Find("FirstObstacle").transform.position;

        // Calculate ball trayectory.
        Vector3 ballPos = ball.transform.position;
        Vector3 obstPos = firstObstacle.transform.position;

        Vector3 direction = (obstPos - ballPos) / 2;

        ballRb.AddForce(direction);
    }
}
