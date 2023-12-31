﻿using UnityEngine;
using UnityEngine.UI;

public class UnitStatusImage : MonoBehaviour
{
    public Color operationCircle;
    public Color operationLine;
    public Color stopCircle;
    public Color stopLine;
    public Color alarmCircle;
    public Color alarmLine;
    [Space]
    public Sprite[] primarys;
    public Sprite[] secondarys1;
    public Sprite[] secondarys2;
    [Space]
    public Image primary;
    public Image secondCircle;
    public Image secondLine;
    [Space]
    public int frameSpeed = 20;

    private UnitLevelControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
    }

    void Update()
    {
        ChangeImage(primary, script.statusPri, primarys, false);
        ChangeImage(secondCircle, script.statusSec, secondarys1, false);
        ChangeImage(secondLine, script.statusSec, secondarys2, true);
    }

    private void ChangeImage(Image image, int status, Sprite[] sprites, bool line)
    {
        switch (status)
        {
            case 0:
                if (line) { image.color = operationLine; }
                else { image.color = operationCircle; }
                image.sprite = sprites[(int)(Time.time * frameSpeed) % sprites.Length];
                break;

            case 1:
                if (line) { image.color = stopLine; }
                else { image.color = stopCircle; }
                image.sprite = sprites[sprites.Length - 1];
                break;

            case 2:
                if (line) { image.color = alarmLine; }
                else { image.color = alarmCircle; }
                image.sprite = sprites[(int)(Time.time * frameSpeed) % sprites.Length];
                break;
        }
    }
}