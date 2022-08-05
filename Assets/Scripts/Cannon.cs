using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    GameManager GM;
    GameObject ball;
    GameObject firstObstacle;
    Rigidbody ballRb;
    [SerializeField] private float shotImpulseForce = 3.5f;

    public delegate void ThrowedBall();
    public event ThrowedBall tb;

    void Start()
    {
        GM = GameManager.Instance;
        ball = GameObject.Find("Ball");
        firstObstacle = GameObject.Find("FirstObstacle");
        ballRb = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GM.IsGameOver && GM.CanThrow() && Input.GetKeyUp(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        Vector3 firstObstaclePosition = GameObject.Find("FirstObstacle").transform.position;

        Vector3 ballPos = ball.transform.position;
        Vector3 obstPos = firstObstacle.transform.position;

        Vector3 direction = (obstPos - ballPos) / 2;

        ballRb.AddForce(direction * shotImpulseForce, ForceMode.Impulse);

        if (tb != null)
        {
            tb();
        }
        else
        {
            Debug.Log("Your are not subscribed to throwedBall event");
        }
    }
}
