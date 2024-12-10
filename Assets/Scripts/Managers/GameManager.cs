using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public GameObject[] ships;
    public ShipData[] shipsStats;
    public int shipIndex;
    public Transform shipSpawnLocation;
    public int score;
    public int highestScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreCountText;
    public TextMeshProUGUI highestScoreCountText;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    bool isGamePaused;

    private void Start()
    {
        Time.timeScale = 1.0f;
        if (scoreText != null)
            UpdateScore();
        Cursor.lockState = CursorLockMode.Confined;
        highestScore = PlayerPrefs.GetInt("highestScore", highestScore);
        shipIndex = PlayerPrefs.GetInt("shipIndex", shipIndex);
        if (ships.Length != 0)
            ships[shipIndex].SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOverScreen == null || gameOverScreen.activeSelf) {
                return;
            }
            pauseScreen.SetActive(!isGamePaused);
            isGamePaused = !isGamePaused;
            Time.timeScale = isGamePaused ? 0f : 1f;
        }
    }

    public void IncreaseScore(int bonusScore)
    {
        score += bonusScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateHighestScore()
    {
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("highestScore", highestScore);
        }
    }

    public void UpdateGameOverScores()
    {
        gameOverScreen.SetActive(true);
        UpdateHighestScore();
        scoreCountText.text = "Score: " + score.ToString();
        highestScoreCountText.text = "Hi Score: " + highestScore.ToString();
    }

    public void ResetHiScore()
    {
        PlayerPrefs.SetInt("highestScore", 0);
        PlayerPrefs.SetInt("shipIndex", 0);

        for(int i = 1; i < shipsStats.Length; i++)
        {
            shipsStats[i].isBought = false;
        }
    }

    public void RestartCurrentLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void ContinueCurrentLevel()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadNextLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadShopMenu()
    {
        SceneManager.LoadScene(2);
    }
}
