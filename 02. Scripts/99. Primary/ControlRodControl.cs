using UnityEngine;

public class ControlRodControl : MonoBehaviour
{
    public GameObject[] rods;

    private bool up = false;
    private float speed = 5.0f;
    private int count = 0;

    void Start()
    {

    }

    void Update()
    {
        if (up)
        {
            if (rods[count].transform.localPosition.y < 0.9f)
            {
                rods[count].transform.localPosition = Vector3.Lerp(
                    new Vector3(rods[count].transform.localPosition.x, rods[count].transform.localPosition.y, rods[count].transform.localPosition.z),
                    new Vector3(rods[count].transform.localPosition.x, 0.943f, rods[count].transform.localPosition.z),
                    speed * Time.deltaTime);
            }
            else { if (count < 31) { count++; } }
        }
        else
        {
            for (int i = 0; i < rods.Length; i++)
            {
                rods[i].transform.localPosition = Vector3.Lerp(
                    new Vector3(rods[i].transform.localPosition.x, rods[i].transform.localPosition.y, rods[i].transform.localPosition.z),
                    new Vector3(rods[i].transform.localPosition.x, -0.1616112f, rods[i].transform.localPosition.z),
                    speed * Time.deltaTime);
            }
        }
    }

    public void _ClickRodUp() { up = true; }
    public void _ClickRodDown()
    {
        up = false;
        count = 0;
    }
}