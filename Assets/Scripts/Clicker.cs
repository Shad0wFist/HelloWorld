using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject floatingTextPref;
    [SerializeField] private Transform floatingTextArea;
    [SerializeField] private int scoreIncrement = 1; // Значение, на которое увеличивается счёт

    private int score = 0;

    void Start()
    {
        // Инициализация текста при запуске
        scoreText.text = score.ToString();
    }

    public void IncrementScore()
    {
        score += scoreIncrement;
        scoreText.text = score.ToString(); // Обновление текста

        // Создание всплывающего текста
        SpawnFloatingText(scoreIncrement);
    }

    private void SpawnFloatingText(int amount)
    {
        // Получаем RectTransform области
        RectTransform areaRect = floatingTextArea.GetComponent<RectTransform>();

        // Генерируем случайную позицию внутри области
        Vector2 randomPosition = new Vector2(
            Random.Range(areaRect.rect.xMin, areaRect.rect.xMax),
            Random.Range(areaRect.rect.yMin, areaRect.rect.yMax)
        );

        GameObject floatingText = Instantiate(floatingTextPref, floatingTextArea);
        floatingText.GetComponent<RectTransform>().localPosition = randomPosition;
        floatingText.GetComponent<TextMeshProUGUI>().text = "+" + amount.ToString();
    }
}