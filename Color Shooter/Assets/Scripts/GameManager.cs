using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameScore = 0;
    float playTime = 0.0f;

    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI platTimeText;
    [SerializeField] GameObject gameOver;

    void Start()
    {
        gameScoreText.text = "Score: " + gameScore;
        platTimeText.text = "Time: " + playTime.ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        platTimeText.text = "Time: " + playTime.ToString("0.0");
    }

    public void IncreseScore(int score)
    {
        gameScore += score;
        gameScoreText.text = "Score: " + gameScore;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);

        Time.timeScale = 0;
        
    }
}
