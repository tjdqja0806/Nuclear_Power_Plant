﻿using TMPro;
using UnityEngine;

public class RPASTableText : MonoBehaviour
{
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI valueText;
    public Color normal;
    public Color change;
    [Space]
    public string symbolName;
    public float min;
    public float max;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;

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
            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }
            valueText.text = string.Format("{0:N1}", value) + "";
            if (value % 3 == 0)
            {
                valueText.color = change;
                typeText.color = change;
            }
            else
            {
                valueText.color = normal;
                typeText.color = normal;
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}