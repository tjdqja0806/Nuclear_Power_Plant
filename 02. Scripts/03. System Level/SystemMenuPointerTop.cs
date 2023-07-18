using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemMenuPointerTop : MonoBehaviour
{
    public Sprite normal;
    public Sprite over;
    [Space]
    public TextMeshProUGUI text;

    private Image image;

    void Start() { image = GetComponent<Image>(); }

    public void PointerEnter()
    {
        image.sprite = over;
        text.color = Color.black;
    }

    public void PointerExit()
    {
        image.sprite = normal;
        text.color = Color.white;
    }
}