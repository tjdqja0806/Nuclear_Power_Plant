using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemMenuPointer : MonoBehaviour
{
    public Sprite normalMain;
    public Sprite overMain;
    public Sprite selectMain;
    public Image imageMain;
    public TextMeshProUGUI text;
    [Space]
    public Sprite normalChart;
    public Sprite overChart;
    public Image imageChart;
    [Space]
    public Sprite normalSub;
    public Sprite selectSub;
    public Image imageSub;
    [Space]
    public int index = 0;

    private SystemMenuController script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<SystemMenuController>();
    }

    public void PointerEnterMain()
    {
        imageMain.sprite = overMain;
        text.color = Color.white;
        imageSub.sprite = normalSub;
    }

    public void PointerExitMain()
    {
        if (script.items[index].mainActive) { PointerSelectMain(); }
        else
        {
            imageMain.sprite = normalMain;
            text.color = Color.white;
            imageSub.sprite = normalSub;
        }
    }

    public void PointerSelectMain()
    {
        imageMain.sprite = selectMain;
        text.color = Color.black;
        imageSub.sprite = selectSub;
    }

    public void PointerEnterChart()
    {
        imageChart.sprite = overChart;
    }

    public void PointerExitChart()
    {
        imageChart.sprite = normalChart;
    }
}