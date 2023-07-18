using UnityEngine;
using UnityEngine.UI;

public class PlantStatusBox : MonoBehaviour
{
    public Image threePri;
    public Image threeSec;
    public Image fourPri;
    public Image fourSec;
    [Space]
    public Image threePriAni;
    public Image threeSecAni;
    public Image fourPriAni;
    public Image fourSecAni;
    [Space]
    public Sprite transparent;
    public Sprite stop;
    public Sprite warning;
    [Space]
    public Sprite[] primarys;
    public Sprite[] secondarys;
    [Space]
    public int frameSpeed = 10;

    private PlantLevelControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
    }

    void Update()
    {
        ChangeImage(threePri, threePriAni, script.status3rdPri, primarys);
        ChangeImage(threeSec, threeSecAni, script.status3rdSec, secondarys);
        ChangeImage(fourPri, fourPriAni, script.status4thPri, primarys);
        ChangeImage(fourSec, fourSecAni, script.status4thSec, secondarys);
    }

    private void ChangeImage(Image icon, Image animation, int status, Sprite[] sprites)
    {
        switch (status)
        {
            case 0:
                icon.sprite = transparent;
                animation.sprite = sprites[(int)(Time.time * frameSpeed) % sprites.Length];
                break;

            case 1:
                icon.sprite = stop;
                animation.sprite = sprites[0];
                break;

            case 2:
                icon.sprite = warning;
                animation.sprite = sprites[(int)(Time.time * frameSpeed) % sprites.Length];
                break;
        }
    }
}