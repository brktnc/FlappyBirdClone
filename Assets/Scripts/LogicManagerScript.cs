using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] Text scoreText;
    [SerializeField] int highScore;
    [SerializeField] Text highscoreText;
    [SerializeField] GameObject gameOverScreen;
    GhostScript ghostScript;
    public AudioSource jumpSFX;

    void Awake()
    {
        gameOverScreen.SetActive(false);
        ghostScript = FindObjectOfType<GhostScript>();
        setLatestHighScore();
    }

    public int HighScore
    {
        set
        {
            highScore = value;
            highscoreText.text = "Highscore = " + value.ToString();
        }
    }

    public void scoreIncrement(int scoreToAdd)
    {
        if (ghostScript.ghostIsAlive)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            jumpSFX.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        setHighScoreIfGreater();
        gameOverScreen.SetActive(true);
    }

    private void setLatestHighScore()
    {
        HighScore = PlayerPrefs.GetInt("highScore", 0);
    }

    public void setHighScoreIfGreater()
    {
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
        }
    }

}
