using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
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
        if (Input.GetMouseButtonDown(1) && anim.GetInteger("AnimChange") == 0)
        {
            anim.SetInteger("AnimChange", 1);
        }
        else if(Input.GetMouseButtonDown(1) && anim.GetInteger("AnimChange") == 1)
        {
            anim.SetInteger("AnimChange", 0);
        }
    }
}
