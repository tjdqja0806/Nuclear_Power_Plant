using TMPro;
using UnityEngine;

public class TextStatusScript : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    [Space]
    public string symbolName;
    public string normalText;
    public string alarmText;

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

            if (dataAgent.isAuto) { valueText.text = normalText + ""; }
            else
            {
                value = dataAgent.getValueBySymbolName(symbolName);
                if (value >= 1) { valueText.text = normalText + ""; }
                else { valueText.text = alarmText + ""; }
            }
        }
    }
}