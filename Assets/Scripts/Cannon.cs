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
        if (!GM.IsGameOver && GM.CanThrow() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Game Over and spacebar has benn pressed");
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

        Debug.Log("Throw a new ball now!");
        ballRb.AddForce(direction);
    }
}
