using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    GameManager GM;
    LevelManager LM;
    GameObject ball;
    GameObject firstObstacle;
    Rigidbody ballRb;
    [SerializeField] private float shotImpulseForce = 3.5f;

    public delegate void ThrowedBall();
    public event ThrowedBall throwedBall;

    void Start()
    {
        GM = GameManager.Instance;
        ball = GameObject.Find("Ball");
        firstObstacle = GameObject.Find("FirstObstacle");
        ballRb = ball.GetComponent<Rigidbody>();
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Update()
    {
        if (GM.CanThrow() && Input.GetKeyUp(KeyCode.Space))
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

        if (throwedBall != null)
        {
            throwedBall();
        }
        else
        {
            Debug.Log("Your are not subscribed to throwedBall event");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            // If Ball falls into the cannon, set the status to inactive to
            // allow the User to throw it again
            LM.SetBallInactive();
        }
    }
}
