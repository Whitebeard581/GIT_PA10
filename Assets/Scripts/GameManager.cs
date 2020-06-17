using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    [SerializeField] private Text Txt_Highscore = null;
    private int Score = 0;
    private int Lives = 1;
    private int HighScore = 0;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;

        HighScore = PlayerPrefs.GetInt("HIGHSCORE");
        Txt_Highscore.text = "HIGHSCORE : " + HighScore;
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
    }

    public void GameOver()
    {
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", Score);
        }
        SceneManager.LoadScene("GameLose");
    }

    public void UpdateLives()
    {
        Lives--;

        if (Lives <= 0)
        {
            GameOver();
        }
    }

    public void UpdateScore()
    {
        Score++;
        Txt_Score.text = "SCORE : " + Score;
    }
}
