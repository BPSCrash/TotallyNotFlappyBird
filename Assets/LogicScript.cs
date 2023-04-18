using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    private int highScore;
    public TMP_Text scoreText;
    public TMP_Text highScoreCounter;
    public GameObject gameOverScreen;
    public AudioSource boomSFX;


    private class PrefKeys
    {
       public const string HIGHSCORE_KEY = "HighScore";
    }
    public void Start()
    {
        if (PlayerPrefs.GetInt(PrefKeys.HIGHSCORE_KEY) != null)
        {
            highScore = PlayerPrefs.GetInt(PrefKeys.HIGHSCORE_KEY);
            highScoreCounter.text = highScore.ToString();
        } else
        {
            PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_KEY, 0);
            highScore = PlayerPrefs.GetInt(PrefKeys.HIGHSCORE_KEY);
            highScoreCounter.text = highScore.ToString();
        }
       
    }

    [ContextMenu("Increase Score")]

    public void AddScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeSelf)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            boomSFX.Play();
        }
       
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if(playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_KEY, highScore);
        }
        
        gameOverScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
