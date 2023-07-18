using UnityEngine;

public class HistoryOnOff : MonoBehaviour
{
    public GameObject image;

    public void _ClickOpen() { image.SetActive(true); }
    public void _ClickClose() { image.SetActive(false); }
}