using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameStarted = false;
    public Text scoreText;
    public Text scoreShow;
    int lives = 2;
    int score = 0;

    public bool gameOver = false;

    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
    public Sprite BrokenHeart;

    public GameObject gameoverPanel;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
    public void StartGame()
    {
        gameStarted = true;
    }
    public void GameOver()
    {
        gameOver = true;
        player.SetActive(false);
        gameoverPanel.SetActive(true);
        scoreShow.text = score.ToString();
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateLives()
    {
        if (lives == 0)
        {
            live1.gameObject.GetComponent<SpriteRenderer>().sprite = BrokenHeart;
            GameOver();
        }
        else
        {
            lives--;
            if (lives == 1)
            {
                live3.gameObject.GetComponent<SpriteRenderer>().sprite = BrokenHeart;
            }
            else if (lives == 0)
            {
                live2.gameObject.GetComponent<SpriteRenderer>().sprite = BrokenHeart;
            }
        }
    }

    public void UpdateScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

}
