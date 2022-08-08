using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    GameManager GM;

    public Vector3 BallInitialPosition { get; private set; }

    // ENCAPSULATION
    private TextMeshProUGUI scoreUI;
    private TextMeshProUGUI bestScoreUI;
    private GameObject gameOverUI;

    void Start()
    {
        GM = GameManager.Instance;

        // Set Ball as active when Cannon throws it.
        Cannon cannon = GameObject.Find("Cannon").GetComponent<Cannon>();
        cannon.throwedBall += SetBallActive;

        // Set Ball as inactive when ResetBall reset ball's position.
        ResetBall bottom = GameObject.Find("Bottom").GetComponent<ResetBall>();
        bottom.restardedBall += ResetBallPosition;

        scoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        bestScoreUI = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
        gameOverUI = GameObject.Find("GameOverUI").gameObject;
        gameOverUI.SetActive(false);

        BallInitialPosition = GameObject.Find("Ball").GetComponent<Transform>().position;

        UpdateBestScore();
    }

    void Update()
    {
        if (GM.IsGameOver)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void AddScore(int point)
    {
        GM.CurrentScore += point;

        scoreUI.text = GM.CurrentPlayer + "'s score: " + GM.CurrentScore;

        UpdateBestScore();
    }

    public void UpdateBestScore()
    {
        if (GM.CurrentScore > GM.BestScore)
        {
            GM.BestPlayer = GM.CurrentPlayer;
            GM.BestScore = GM.CurrentScore;
        }

        bestScoreUI.text = "Best score: " + GM.BestScore + " by " + GM.BestPlayer;
    }

    public void ResetBallPosition()
    {
        GameObject.Find("Ball").GetComponent<Transform>().position = BallInitialPosition;
        GameObject.Find("Ball").GetComponent<Rigidbody>().velocity = Vector3.zero;

        GM.BallActive = false;
        GM.BallCount++;

        if (!GM.HasRetries())
        {
            GM.IsGameOver = true;
        }
    }

    public void SetBallActive()
    {
        GM.BallActive = true;
    }

    public void SetBallInactive()
    {
        GM.BallActive = false;
    }

    public void RestartGameSession()
    {
        GM.BallCount = 0;
        GM.CurrentScore = 0;
        GM.IsGameOver = false;
        //gameOverUI.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
