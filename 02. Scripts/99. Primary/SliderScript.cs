using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    [Space]
    public float min;
    public float max;
    public string unit;
    public TextMeshProUGUI text;

    private float timer = 0.0f;
    private double value;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1.0f;
            value = randomValue(min, max);
            slider.value = (float)value;
            text.text = float.Parse(string.Format("{0:0.0}", value)) + " " + unit;
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}