using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        // Инициализация текста при запуске
        scoreText.text = score.ToString();
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString(); // Обновляем текст
    }
}