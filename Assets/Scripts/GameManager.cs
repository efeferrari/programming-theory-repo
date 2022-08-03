using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }
    public int  BallLimit { get; private set; }
    public int  BallCount { get; set; }
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
        BallLimit = 3;
        BallCount = 0;
        CurrentScore = 0;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool CanThrow()
    {
        if (BallCount < BallLimit)
        {
            return true;
        }

        return false;
    }

    public void AddPoint()
    {
        CurrentScore += 1;
    }
}
