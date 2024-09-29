using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{

  

    int score;
    int lives = 3;
    int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI highScoreText;

    //game over panel
    public bool isGameOver = false;

    public GameObject PauseMenuScreen;


    public GameObject gameOverScreen;
    internal static object instance;

    void Start()
    {
        score = 0;
        lives = 3;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
       
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();


        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }



    public void LooseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            Debug.Log("game over");
        }
    }


    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            highScoreText.text = "Best: " + highScore.ToString();
        }

    }
    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives.ToString();
    }


    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    //game over screen
    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void LoseLife()
    {
        lives--;

    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void RetryGame()
    {
        lives = 3;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}


