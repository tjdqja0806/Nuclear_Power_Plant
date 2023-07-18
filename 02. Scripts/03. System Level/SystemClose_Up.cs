using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemClose_Up : MonoBehaviour
{
    public GameObject[] target;
    [Space]
    public GameObject camera;

    private int status;
    private float speed;
    private float distance;
    private SystemCameraMove systemCameraMove;

    private void Start()
    {
        systemCameraMove = GameObject.Find("Main Camera").GetComponent<SystemCameraMove>();
    }
    private void Update()
    {
        distance = Vector3.Distance(target[status].transform.position,
                                    camera.transform.position);
        if (distance > 0.2f)
        {
            camera.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }
        else
        {
            speed = 0;
            systemCameraMove.isCloseUp = false;
        }
    }

    public void Click(int num)
    {
        systemCameraMove.isCloseUp = true;
        status = num;
        speed = 1f;
        camera.transform.LookAt(target[num].transform);
        
    }
}
