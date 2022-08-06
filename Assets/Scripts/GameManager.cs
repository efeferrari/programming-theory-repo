using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver    { get; set; }
    public int  BallLimit     { get; private set; }
    public int  BallCount     { get; set; }
    public bool BallActive    { get; set; }

    public string CurrentPlayer { get; set; }
    public int    CurrentScore  { get; set; }
    public string BestPlayer    { get; set; }
    public int    BestScore     { get; set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        IsGameOver = false;
        BallActive = false;
        BallLimit  = 3;
        BallCount  = 0;

        CurrentPlayer = "";
        CurrentScore = 0;

        SavedData sd = GetSavedData();
        BestPlayer = sd.player;
        BestScore  = sd.score;
    }

    void Update()
    {
        if (IsGameOver)
        {
            UpdateBestScore();
        }
    }

    public bool CanThrow()
    {
        return !IsGameOver && HasRetries() && !BallActive;
    }

    public bool HasRetries()
    {
        return BallCount < BallLimit;
    }

    public void CloseGame()
    {
        UpdateBestScore();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
# endif
    }

    /*** SAVE DATA ***/
    [System.Serializable]
    class SavedData
    {
        public int score;
        public string player;
    }

    private void UpdateBestScore()
    {
        SavedData currentSavedData = GetSavedData();

        if (currentSavedData.score < CurrentScore)
        {
            currentSavedData.score = CurrentScore;
            currentSavedData.player = CurrentPlayer;

            string jsonData = JsonUtility.ToJson(currentSavedData);
            string path = Application.persistentDataPath + "/saveFileOOPp.json";

            File.WriteAllText(path, jsonData);
        }
    }

    public void LoadData()
    {
        SavedData currentSavedData = GetSavedData();

        BestPlayer = currentSavedData.player;
        BestScore = currentSavedData.score;
    }

    private SavedData GetSavedData()
    {
        string path = Application.persistentDataPath + "/saveFileOOPp.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<SavedData>(json);
        }

        return new SavedData();
    }
}
