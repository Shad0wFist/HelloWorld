using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float fadeDuration = 1f;
    private TextMeshProUGUI textMesh;
    private Color textColor;
    private float timeElapsed = 0f;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textColor = textMesh.color; // Сохраняем исходный цвет текста
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // Рассчитываем прозрачность текста
        timeElapsed += Time.deltaTime;
        float alpha = Mathf.Lerp(1, 0, timeElapsed / fadeDuration);
        textMesh.color = new Color(textColor.r, textColor.g, textColor.b, alpha);

        // Удаляем объект, когда текст полностью исчезнет
        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
