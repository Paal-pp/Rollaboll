using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}
