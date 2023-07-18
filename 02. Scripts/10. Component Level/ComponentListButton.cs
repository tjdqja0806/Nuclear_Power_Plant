using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentListButton : MonoBehaviour
{
    public Image popupImage;
    private bool isClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick) { popupImage.gameObject.SetActive(true); }
        else { popupImage.gameObject.SetActive(false); }
    }
    public void Click()
    {
        isClick = !isClick;
    }
}
