using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentClickEvent : MonoBehaviour
{
    public Sprite origin;
    public Sprite click;

    public Image button;

    private bool isChange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChange) { button.sprite = click; }
        else { button.sprite = origin; }
    }
    public void Click()
    {
        isChange = !isChange;
    }
}
