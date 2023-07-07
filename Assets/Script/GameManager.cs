using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;
    public int highScore = 0;
    public Text scoreText;
    public GameObject GameoverPanel;
    public Text highScoreText;

  
    void Awake()
    {
        GameoverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = highScore.ToString();

    }

    
    public void IncreaseScore()
    {
        score += 2;
        scoreText.text = score.ToString();

        if (score > highScore) 
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        GameoverPanel.SetActive(true);
        
    }
    public void RestartGame()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Finish"))
        {
            Destroy(g);
        }
        GameoverPanel.SetActive(false );
        Time.timeScale = 1;
        score = 0;
        scoreText.text = "0";
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
