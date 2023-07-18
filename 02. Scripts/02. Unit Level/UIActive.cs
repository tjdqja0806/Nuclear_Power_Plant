using UnityEngine;

public class UIActive : MonoBehaviour
{
    public GameObject statusUIGroup;
    public Animator animator;

    private PlantLevelControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
    }

    void Update()
    {
        statusUIGroup.SetActive(script.isUIActive);
        animator.SetBool("Active", script.isUIActive);
    }
}