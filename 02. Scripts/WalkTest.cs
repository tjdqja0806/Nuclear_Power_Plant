using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTest : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);
        }
        else
            anim.SetBool("Walk", false);
    }
}
