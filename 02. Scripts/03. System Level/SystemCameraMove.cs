using SpaceNavigatorDriver;
using UnityEngine;

public class SystemCameraMove : MonoBehaviour
{
    private float moveSpeed3D = 5f;
    private float rotationSpeed3D = 50f;

    public GameObject target;

    public float moveSpeed = 1f;
    public float rotateSpeed = 30f;

    private float _x;
    private float _y;
    public bool isCloseUp = false;

    void Start()
    {

    }

    void Update()
    {
        if (!isCloseUp)
        {
            Move();
            Rotation();
            KeybordMove();
            if (Input.GetMouseButton(2))
            {
                float _x = Input.GetAxis("Mouse X");
                float _y = Input.GetAxis("Mouse Y");

                transform.RotateAround(target.transform.position, Vector3.down, _x * rotateSpeed * Time.deltaTime);
                transform.RotateAround(target.transform.position, Vector3.left, _y * rotateSpeed * Time.deltaTime);
                //transform.Translate(Vector3.left * rotateSpeed * -_x * Time.deltaTime, Space.Self);
                //transform.Translate(Vector3.down * rotateSpeed * -_y * Time.deltaTime, Space.Self);
                transform.LookAt(target.transform);
            }

        }
    }

    private void Move()
    {
        transform.Translate(SpaceNavigator.Translation * moveSpeed3D * Time.deltaTime, Space.Self);
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg * rotationSpeed3D * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * rotationSpeed3D * Time.deltaTime, Space.Self);
    }

    private void KeybordMove()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.E))
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);
    }
}