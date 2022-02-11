using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject timerText;
    public GameObject scoreText;
    public GameObject gameoverText;
    public GameObject gameclearText;
    public float defualtTime = 60.0f;
    public int score = 100;
    public int clearScore = 2000;

    public void AddedScore()
    {
        this.score += 100;
    }
    public void DecreasedScore()
    {
        this.score -= 50;
    }
    // Update is called once per frame
    void Update()
    {
        this.defualtTime -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = "Time : " + this.defualtTime.ToString("F2");
        this.scoreText.GetComponent<Text>().text = "Score : " + this.score.ToString();
        if(this.score <= 0 || this.defualtTime <= 0)
        {
            Time.timeScale = 0;
            this.gameoverText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameScene");
                Time.timeScale = 1;
            }
        }
        if(this.score >= this.clearScore)
        {
            Time.timeScale = 0;
            this.gameclearText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameScene");
                Time.timeScale = 1;
            }
        }
    }
}
