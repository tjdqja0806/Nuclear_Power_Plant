using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapButton : MonoBehaviour
{

    public Image[] buttonImage;
    [Space (10f)]
    public Sprite clickImage;
    public Sprite originImage;
    public Sprite overImage;

    public bool isChange = false;
    private bool isOver = false;
    private int overStatus;
    private int buttonStatus;

    private TourCameraMove tourCameraMove;

    // Start is called before the first frame update
    void Start()
    {
        tourCameraMove = GameObject.Find("Character").GetComponent<TourCameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttonImage.Length; i++)
        {
            if (i == (tourCameraMove.status)) { buttonImage[tourCameraMove.status].sprite = clickImage; }
            else { buttonImage[i].sprite = originImage; }
        }
        //Check();
    }
    public void Click(int num)
    {
        isChange = !isChange;
        buttonStatus = num;
        tourCameraMove.status = num;
        tourCameraMove.isMovePosition = true;
    }
}
