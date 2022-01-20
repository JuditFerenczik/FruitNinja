using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [Header("Game Over")]
    public GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI gameOverPanelScoreText;
    [SerializeField] TextMeshProUGUI gameOverPanelHighScoreText;
    [Header("Sounds")]
    public AudioClip[] slicedSounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        GetHighScore();
    }

    private void GetHighScore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;

    }
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: " + score;
        }
    }
    public void OnBombHit()
    {
        gameOverPanel.SetActive(true);
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + highscore.ToString();
        Time.timeScale = 0;
        Debug.Log("HIT");
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text =score.ToString();
        gameOverPanel.SetActive(false);
       // gameOverPanelScoreText.text = "Score: 0";
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("interactable"))
        {
            Destroy(g);
        }
        Time.timeScale = 1;
    }
    public void PlAySounds()
    {
        AudioClip randomSound = slicedSounds[Random.Range(0, slicedSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
