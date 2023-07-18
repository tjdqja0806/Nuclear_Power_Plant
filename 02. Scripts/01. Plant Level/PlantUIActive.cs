using UnityEngine;

public class PlantUIActive : MonoBehaviour
{
    public Animator animator;

    private PlantLevelControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
    }

    void Update()
    {
        animator.SetBool("Active", script.isUIActive);
    }
}