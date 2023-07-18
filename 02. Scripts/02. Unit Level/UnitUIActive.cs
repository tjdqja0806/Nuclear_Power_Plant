using UnityEngine;

public class UnitUIActive : MonoBehaviour
{
    public GameObject statusUIGroup;
    public Animator animator;
    public Animator animator2;

    private UnitLevelControl script;

    void Start()
    {
        script = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
    }

    void Update()
    {
        statusUIGroup.SetActive(script.isUIActive);
        animator.SetBool("Active", script.isUIActive);
        if (script.isTourActive) { animator2.SetBool("Active", false); }
        else { animator2.SetBool("Active", script.isUIActive); }
    }
}