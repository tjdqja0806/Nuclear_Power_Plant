using UnityEngine;

public class WarningFrameCamera : MonoBehaviour
{
    public GameObject camera;
    public GameObject frame;

    private AlarmControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<AlarmControl>();
    }

    void Update()
    {
        camera.SetActive(script.isAlarm);
        frame.SetActive(script.isAlarm);
    }
}