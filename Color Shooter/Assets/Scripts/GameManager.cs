using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        spawner.CancelInvoke();
        
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
