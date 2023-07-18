using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorePattern : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;

    private float timer = 0.0f;
    private float dummy = 0;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1.0f;
            dummy = randomValue(0, 100);
            image.color = returnCoreColor(dummy);
            text.text = Mathf.Round(dummy * 0.01f) + "";
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private Color returnCoreColor(float value)
    {
        Color color = new Color(randomValue(0, 255) / 255f, randomValue(0, 255) / 255f, randomValue(0, 255) / 255f);

        if (value == 100) { color = new Color(165 / 255f, 0 / 255f, 0 / 255f); }
        else if (value >= 94.4) { color = new Color(192 / 255f, 0 / 255f, 0 / 255f); }
        else if (value >= 88.9) { color = new Color(225 / 255f, 20 / 255f, 0 / 255f); }
        else if (value >= 83.3) { color = new Color(225 / 255f, 50 / 255f, 0 / 255f); }
        else if (value >= 77.8) { color = new Color(255 / 255f, 96 / 255f, 0 / 255f); }
        else if (value >= 72.2) { color = new Color(255 / 255f, 160 / 255f, 0 / 255f); }
        else if (value >= 66.7) { color = new Color(255 / 255f, 192 / 255f, 60 / 255f); }
        else if (value >= 61.1) { color = new Color(255 / 255f, 232 / 255f, 120 / 255f); }
        else if (value >= 55.6) { color = new Color(255 / 255f, 250 / 255f, 220 / 255f); }
        else if (value >= 50.0) { color = new Color(230 / 255f, 255 / 255f, 255 / 255f); }
        else if (value >= 44.4) { color = new Color(200 / 255f, 250 / 255f, 255 / 255f); }
        else if (value >= 38.9) { color = new Color(160 / 255f, 240 / 255f, 255 / 255f); }
        else if (value >= 33.3) { color = new Color(130 / 255f, 210 / 255f, 255 / 255f); }
        else if (value >= 27.8) { color = new Color(80 / 255f, 180 / 255f, 250 / 255f); }
        else if (value >= 22.2) { color = new Color(60 / 255f, 160 / 255f, 240 / 255f); }
        else if (value >= 16.7) { color = new Color(30 / 255f, 110 / 255f, 220 / 255f); }
        else if (value >= 11.1) { color = new Color(15 / 255f, 75 / 255f, 165 / 255f); }
        else if (value >= 5.6) { color = new Color(10 / 255f, 50 / 255f, 120 / 255f); }
        else { color = new Color(0 / 255f, 25 / 255f, 80 / 255f); }

        return color;
    }
}