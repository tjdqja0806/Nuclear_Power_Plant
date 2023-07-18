using SpaceNavigatorDriver;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 0.3f;
    public float rotationSpeed = 1.0f;
    public float areaLimited = 0.35f;

    private float moveSpeed = 0.2f;

    void Start()
    {
        moveSpeed = speed;
    }

    void Update()
    {
        Move();
        Rotation();
        //AreaLimitation();
    }

    private void Move()
    {
        transform.Translate(SpaceNavigator.Translation * moveSpeed, Space.Self);
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg * rotationSpeed, Space.World);
        transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * rotationSpeed, Space.Self);
    }

    private void AreaLimitation()
    {
        if (transform.position.y < areaLimited && SpaceNavigator.Translation.y < 0)
        {
            moveSpeed = 0;
        }
        else if (moveSpeed == 0 && SpaceNavigator.Translation.y > 0)
        {
            moveSpeed = speed;
        }
    }
}