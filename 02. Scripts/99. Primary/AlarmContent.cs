using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmContent : MonoBehaviour
{
    public Sprite phiNormal;
    public Sprite phiWarning;
    public Image imagePHI;
    [Space]
    public Sprite circleNormal;
    public Sprite circleWarning;
    public Image imageCircle;
    [Space]
    public TextMeshProUGUI text;

    private AlarmOnOff script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<AlarmOnOff>();
    }
    void Update()
    {
        if (!script.isActive)
        {
            imagePHI.sprite = phiNormal;
            imageCircle.sprite = circleNormal;
            text.text = "NORMAL";
        }
        else
        {
            imagePHI.sprite = phiWarning;
            imageCircle.sprite = circleWarning;
            text.text = "Warning";
        }
    }
}