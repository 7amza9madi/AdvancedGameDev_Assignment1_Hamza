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
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.text = "0";
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            scoreText.text = "Coins: " + coins;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            isGameOver = true;
            timerText.text = "You Win!";

        }
    }
}