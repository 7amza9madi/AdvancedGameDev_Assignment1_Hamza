using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int coins = 0;
    public float timeLeft = 30f;
    bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject losePanel;
    public GameObject winPanel;
    void Update()
    {
        if (isGameOver) return;

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();
        }
        else
        {
            ShowLoseScreen();
        }
    }

    public void CollectCoin()
    {
        coins++;
        scoreText.text = "Coins: " + coins;
    }

    public void ShowWinScreen()
    {
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowLoseScreen()
    {
        isGameOver = true;
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}