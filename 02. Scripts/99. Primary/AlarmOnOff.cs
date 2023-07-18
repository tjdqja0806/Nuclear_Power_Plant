using System.Collections;
using UnityEngine;

public class AlarmOnOff : MonoBehaviour
{
    public GameObject image;
    [HideInInspector]
    public bool isActive = false;
    [HideInInspector]
    public bool isOverflow = false;
    [HideInInspector]
    public bool isRadiation = false;
    [HideInInspector]
    public bool isEarthquake = false;

    public CameraShake cameraShake;
    public GameObject overflow;
    public GameObject radiation;

    private IEnumerator coroutine;

    private void Update()
    {
        coroutine = cameraShake.ShakeCamera();
    }
    public void _ClickAlarm()
    {
        isActive = !isActive;
        image.SetActive(isActive);

        isRadiation = false;
        isOverflow = false;
        isEarthquake = false;
        overflow.SetActive(false);
        radiation.SetActive(false);
        StopCoroutine(coroutine);
        cameraShake.shakeCamera.localPosition = cameraShake.originPos;
        cameraShake.shakeCamera.localRotation = cameraShake.originRot;
    }
    public void _ClickEarthquake()
    {
        isEarthquake = !isEarthquake;
        if (isEarthquake)
            StartCoroutine(coroutine);
        else if(!isEarthquake)
        {
            StopCoroutine(coroutine);
            cameraShake.shakeCamera.localPosition = cameraShake.originPos;
            cameraShake.shakeCamera.localRotation = cameraShake.originRot;
        }

        isActive = false;
        isRadiation = false;
        isOverflow = false;
        overflow.SetActive(false);
        radiation.SetActive(false);
        image.SetActive(false);
    }
    public void _ClickOverflow()
    {
        isOverflow = !isOverflow;
        overflow.SetActive(isOverflow);

        isActive = false;
        isRadiation = false;
        isEarthquake = false;
        radiation.SetActive(false);
        image.SetActive(false);
        StopCoroutine(coroutine);
        cameraShake.shakeCamera.localPosition = cameraShake.originPos;
        cameraShake.shakeCamera.localRotation = cameraShake.originRot;
    }
    public void _ClickRadiation()
    {
        isRadiation = !isRadiation;
        radiation.SetActive(isRadiation);

        isActive = false;
        isOverflow = false;
        isEarthquake = false;
        overflow.SetActive(false);
        image.SetActive(false);
        StopCoroutine(coroutine);
        cameraShake.shakeCamera.localPosition = cameraShake.originPos;
        cameraShake.shakeCamera.localRotation = cameraShake.originRot;
    }
}