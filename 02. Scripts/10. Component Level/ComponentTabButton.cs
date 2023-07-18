using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentTabButton : MonoBehaviour
{
    public GameObject[] contents;
    public TextMeshProUGUI[] text;
    private int status = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contents[status].SetActive(true);
        text[status].alpha = 1f;
        for (int i = 0; i< contents.Length; i++)
        {
            if(i != status) { contents[i].SetActive(false); text[i].alpha = 0.2f; }
        }
    }
    public void Click(int num)
    {
        status = num;
    }
}
