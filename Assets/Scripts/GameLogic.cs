using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int coins = 0;
    public float timeLeft = 30f;
    bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            Debug.Log("Time Finished! You collected " + coins + " coins.");
            isGameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("You reached the finish! You collected " + coins + " coins.");
            isGameOver = true;
        }
    }
}