using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssembleSettingScript : MonoBehaviour
{
    [Header("Drag/Auto Button")]
    public Image imageDrag;
    public Image imageAuto;
    public Sprite spriteOn;
    public Sprite spriteOff;
    [Space]
    [Header("DisAssemble/assemble Button")]
    public Button btnDssmbl;
    public Button btnAsmbl;
    [Space]
    [Header("Game Object")]
    public GameObject goDrag;
    public GameObject goAnimate;
    public Animator animator;
    [HideInInspector]
    public bool isback = false;

    private bool statusDrag = true;
    private bool isAnimate = false;
    [Space]
    public TextMeshProUGUI buttonText;
    public GameObject[] background;

    void Start()
    {

    }

    void Update()
    {
        
        if (statusDrag)
        {
            goDrag.SetActive(true);
            goAnimate.SetActive(false);
            //imageDrag.sprite = spriteOn;
            //imageAuto.sprite = spriteOff;
            //btnDssmbl.interactable = false;
        }
        else
        {
            goDrag.SetActive(false);
            goAnimate.SetActive(true);
            //imageDrag.sprite = spriteOff;
            //imageAuto.sprite = spriteOn;
            //btnDssmbl.interactable = true;
        }
    }

    public void ClickBtnDrag()
    {
        if (statusDrag) { isback = true; }
        else { animator.Rebind(); }
        statusDrag = !statusDrag;
        if (statusDrag) 
        { 
            buttonText.text = "Drag"; 
            background[0].SetActive(true);
            background[1].SetActive(false);
        }
        else 
        { 
            buttonText.text = "Auto";
            background[0].SetActive(false);
            background[1].SetActive(true);
        }
    }
    public void ClickBtnDssmbl()
    {
        animator.SetBool("play", true);
        animator.SetFloat("speed", 1.0f);
    }

    public void ClickBtnAsmbl()
    {
        if (statusDrag) { isback = true; }
        else
        {
            animator.SetFloat("speed", -1.0f);
        }
    }
}