using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (Input.GetKey("s"))
        {
            anim.SetBool("runReverse", true);
        }
        else
        {
            anim.SetBool("runReverse", false);
        }

        if (Input.GetKey("d"))
        {
            anim.SetBool("runRight", true);
        }
        else
        {
            anim.SetBool("runRight", false);
        }
        if (Input.GetKey("a"))
        {
            anim.SetBool("runLeft", true);
        }
        else
        {
            anim.SetBool("runLeft", false);
        }
    }
}
