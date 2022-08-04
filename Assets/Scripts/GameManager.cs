using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver   { get; private set; }
    public int  BallLimit    { get; private set; }
    public int  BallCount    { get; set; }
    public bool BallActive   { get; private set; }
    public int  CurrentScore { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        IsGameOver = false;
        BallLimit  = 3;
        BallCount  = 0;
        CurrentScore = 0;
    }

    void Start()
    {
        Cannon cannon = GameObject.Find("Cannon").GetComponent<Cannon>();
        cannon.tb += SetBallActive;
    }

    void Update()
    {
        
    }

    public void SetBallActive()
    {
        BallActive = true;
    }

    public void SetBallInactive()
    {
        BallActive = false;
    }

    public bool CanThrow()
    {
        return (BallCount < BallLimit);
    }

    public void AddPoint()
    {
        CurrentScore += 1;
    }
}
