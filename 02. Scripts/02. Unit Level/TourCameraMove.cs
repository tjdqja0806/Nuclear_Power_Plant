using SpaceNavigatorDriver;
using UnityEngine;
using UnityEngine.UI;

public class TourCameraMove : MonoBehaviour
{

    private float _3DSpeed = 0.5f;
    private float _3DRotateSpeed = 5f;
    private float moveSpeed = 0.06f;
    private float rotateSpeed = 70;
    private float cameraPositionMoveSpeed = 3f;
    private float _x;
    private float _y;
    private int listStatus;
    private int upDown;
    private bool isListClick = false;
    private int clickStatus;
    private Animator anim;
    private CapsuleCollider collider;
    private CameraworkingSpaceNavigatorVDI VDI;

    [HideInInspector]
    public int status = 2;

    [HideInInspector]
    public bool isMovePosition = true;

    [HideInInspector]
    public bool equipmentMove = false;

    [HideInInspector]
    public bool isMoving = false;

    [Space]
    public GameObject[] movePoint;
    [Space]
    public GameObject[] equipmentPoint;
    [Space]
    public GameObject floorImage;
    [Space]
    public Text floorText;
    [Space]
    public GameObject dummy;
    [Space]
    public GameObject JPG;
    [Space]
    public GameObject character;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        VDI = GameObject.Find("EventSystem").GetComponent<CameraworkingSpaceNavigatorVDI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMovePosition && !isListClick)
        {
            Move();
            Rotation();
            WalkAnimation();
        } 
        KeyBoardMove();
        if(Input.GetMouseButton(2))
            KeyBoardRotation();
        CameraPosition();
        PointMove();
        JPG.transform.position = transform.position;
        JPG.transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * SpaceNavigator.Translation.z * Time.deltaTime * _3DSpeed, Space.Self);
        transform.Translate(Vector3.right * SpaceNavigator.Translation.x * Time.deltaTime * _3DSpeed, Space.Self);
        switch (status)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, 0.223f, transform.position.z);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x, 0.305f, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, 0.41606f, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x, 0.53f, transform.position.z);
                break;
        }
        //transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z);
    }
    private void Rotation()
    {
        // 3D 마우스 회전 기준 Input
        // SpaceNavigator.Rotation.eulerAngles.x : SpaceNavigator.Rotation.Pitch() (위, 아래)
        // SpaceNavigator.Rotation.eulerAngles.y : SpaceNavigator.Rotation.Yaw() (좌, 우)
        // SpaceNavigator.Rotation.eulerAngles.z : SpaceNavigator.Rotation.Roll() (왼쪽 기울기, 오른쪽 기울기)
        // Vector3.up : 오른쪽
        // Vector3.down : 왼쪽
        // Vector3.left : 아래
        // Vector3.right : 위
        // Vector3.forward : 오른쪽 기울기
        // Vector3.back : 왼쪽 기울기

        transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg * _3DRotateSpeed, Space.World);

        if (calculateRange(transform.localEulerAngles.x))
        {
            transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * _3DRotateSpeed, Space.Self);
        }
        else
        {
            if (transform.localEulerAngles.x >= 320 && SpaceNavigator.Rotation.Pitch() > 0)
            {
                transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * _3DRotateSpeed, Space.Self);
            }
            else if (transform.localEulerAngles.x <= 40 && SpaceNavigator.Rotation.Pitch() < 0)
            {
                transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * _3DRotateSpeed, Space.Self);
            }
        }
        //if (transform.localEulerAngles.x <= 330 && SpaceNavigator.Rotation.Pitch() > 0)
        //{
        //    transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * rotateSpeed, Space.Self);
        //}

        //Debug.Log("x : " + transform.localEulerAngles.x + ", Pitch : " + SpaceNavigator.Rotation.Pitch());
    }
    private void KeyBoardMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        }
    }
    private void KeyBoardRotation()
    {
        _x = Input.GetAxis("Mouse X");
        _y = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.down * rotateSpeed * -_x * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.left * rotateSpeed * _y * Time.deltaTime, Space.Self);
    }
    private bool calculateRange(float value)
    {
        if ((value >= 0 && value <= 30) || (value >= 330 && value <= 360)) { return true; }
        else { return false; }
    }
    private void CameraPosition()
    {
        if (isMovePosition)
        {
            collider.isTrigger = true;
            isMoving = true;
            character.SetActive(false);
            floorText.text = (status + 1) + "F";
            transform.position = Vector3.Lerp(transform.position, movePoint[status].transform.position, cameraPositionMoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, movePoint[status].transform.localRotation, cameraPositionMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint[status].transform.position) < 0.005)
            {
                collider.isTrigger = false;
                isMovePosition = false;
                character.SetActive(true);
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!equipmentMove)
        {
            switch (other.gameObject.name)
            {
                case "Portal": 
                    floorImage.gameObject.SetActive(true);
                    break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Portal":
                floorImage.gameObject.SetActive(false);
                break;
        }
    }
    public void ListClick(int num)
    {
        isListClick = true;
        floorImage.SetActive(false);
        equipmentMove = true;
        clickStatus = num;
        switch (num)
        {
            case 0: case 1: case 2:
                status = 0;
                break;
            case 3: case 4: case 5:
                status = 1;
                break;
            case 6: case 7: case 8: case 9: case 10:
                status = 2;
                break;
            case 11: case 12:
                status = 3;
                break;
        }
    }
    private void PointMove()
    {
        if (isListClick)
        {
            collider.isTrigger = true;
            isMoving = true;
            character.SetActive(false);
            transform.position = Vector3.Lerp(transform.position, equipmentPoint[clickStatus].transform.position, 3f * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, equipmentPoint[clickStatus].transform.localRotation, 3f * Time.deltaTime);
            if (Vector3.Distance(transform.position, equipmentPoint[clickStatus].transform.position) < 0.005)
            {
                equipmentMove = false;
                isMoving = false;
                character.SetActive(true);
                isListClick = false;
                collider.isTrigger = false;
            }
        }
    }
    private void WalkAnimation()
    {
        /*
        if (SpaceNavigator.Translation.z != 0 || 
            SpaceNavigator.Translation.x != 0 || 
            VDI.isMove ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A)||
            Input.GetKey(KeyCode.S)||
            Input.GetKey(KeyCode.D))
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);
        */
        if (SpaceNavigator.Translation.z > 0 || Input.GetKey(KeyCode.W) || VDI.forward)
            anim.SetBool("Forward", true);
        else if (SpaceNavigator.Translation.z < 0 || Input.GetKey(KeyCode.S) || VDI.reverse)
            anim.SetBool("Backward", true);
        else if ((SpaceNavigator.Translation.z == 0 && SpaceNavigator.Translation.x > 0) || Input.GetKey(KeyCode.D) || VDI.right)
            anim.SetBool("Right", true);
        else if ((SpaceNavigator.Translation.z == 0 && SpaceNavigator.Translation.x < 0) || Input.GetKey(KeyCode.A) || VDI.left)
            anim.SetBool("Left", true);
        else if (SpaceNavigator.Rotation.Yaw() > 0 || VDI.rightRotate)
            anim.SetBool("LeftTurn", true);
        else if (SpaceNavigator.Rotation.Yaw() < 0 || VDI.leftRotate)
            anim.SetBool("RightTurn", true);
        else
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("RightTurn", false); ;
            anim.SetBool("LeftTurn", false);
        }
    }
}
