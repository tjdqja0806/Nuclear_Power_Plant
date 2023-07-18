using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform shakeCamera;
    public Transform ui;
    public bool shakeRotate = false;
    public AnimationCurve animCurve;
    [HideInInspector]
    public Vector3 originPos;
    [HideInInspector]
    public Quaternion originRot;

    private Vector3 uiOriginPos;
    private Quaternion uiOriginRot;
    private float randomSecond;

    private AlarmOnOff alarmOnOff;
    // Start is called before the first frame update
    void Start()
    {
        alarmOnOff = GameObject.Find("EventSystem").GetComponent<AlarmOnOff>();
        originPos = shakeCamera.localPosition;
        originRot = shakeCamera.localRotation;
        uiOriginPos = ui.localPosition;
        uiOriginRot = ui.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        randomSecond = Random.Range(1f, 2f);
    }

    public IEnumerator ShakeCamera(float duration = 2f, 
                                    float magnitudePos = 0.2f, 
                                    float magnitudeRot = 0.01f)
    {
        duration = Random.Range(1f, 2f);
        float passTime = 0.0f;
        while(passTime < duration)
        {
            
            Vector3 shakePos = Random.insideUnitSphere;
            shakeCamera.localPosition = originPos + shakePos * magnitudePos;
            ui.localPosition = uiOriginPos + shakePos * 100 * magnitudePos;

            if (shakeRotate)
            {
                Vector3 shakeRot = new Vector3(0, 0, Mathf.PerlinNoise(Time.time * magnitudeRot, 0.0f)*5f);

                shakeCamera.localRotation = Quaternion.Euler(shakeRot);
                ui.localRotation = Quaternion.Euler(shakeRot);
            }
            passTime += Time.deltaTime;
            magnitudePos = Mathf.Lerp(magnitudePos, 0f, Time.deltaTime);
            yield return null;
        }
        shakeCamera.localPosition = originPos;
        shakeCamera.localRotation = originRot;
        ui.localPosition = uiOriginPos;
        ui.localRotation = uiOriginRot;
        if (alarmOnOff.isEarthquake)
        {
            yield return new WaitForSeconds(randomSecond);
            StartCoroutine(ShakeCamera(duration));
        }
    }
}
