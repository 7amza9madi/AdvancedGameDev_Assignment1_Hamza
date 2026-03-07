using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public int coins = 0;
    public float timeLeft = 30f;
    bool isGameOver = false;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

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
            timerText.text = "Time's Up!";
            isGameOver = true;
            Debug.Log("Game Over!");
        }
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
            Debug.Log("Finished with " + coins + " coins.");
        }
    }
}