using UnityEngine;

public class WaterControl : MonoBehaviour
{
    public Material waterMaterial;
    [Space]
    public string symbolName;
    public float tempMin;
    public float tempMax;
    public float flowMin;
    public float flowMax;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private float tempValue;
    private float flowValue;

    void Start()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1.0f;

            if (dataAgent.isAuto)
            {
                tempValue = randomValue(tempMin, tempMax);
                flowValue = randomValue(flowMin, flowMax);
            }
            else
            {
                // value = dataAgent.getValueBySymbolName(symbolName);
            }

            waterMaterial.SetFloat("Flow_Speed", calculateRate(flowMin, flowMax, flowValue));  // float : 0 ~ 1
            waterMaterial.SetInt("Blending_Branch", 0);  // Boolean : 0 or 1
            waterMaterial.SetFloat("Blending", calculateRate(tempMin, tempMax, tempValue));  // float : 0 ~ 1
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    // Return : 0 ~ 1
    private float calculateRate(float min, float max, float value) { return (float)((value - min) / (max - min)); }
}