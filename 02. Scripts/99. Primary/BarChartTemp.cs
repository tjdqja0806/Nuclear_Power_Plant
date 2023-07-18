using ChartAndGraph;
using UnityEngine;

public class BarChartTemp : MonoBehaviour
{
    public BarChart bar;

    private float timer = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1.0f;
            for (int i = 1; i < 9; i++) { bar.DataSource.SetValue(i + "", "All", float.Parse(string.Format("{0:0}", randomValue(0, 100)))); }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}