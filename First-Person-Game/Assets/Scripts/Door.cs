using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool toggle;
    public Animator animator;

    public void OpenClose()
    {
        toggle = !toggle;
        if(toggle == false)
        {
            animator.ResetTrigger("open");
            animator.SetTrigger("close");
        }

        if (toggle)
        {
            animator.ResetTrigger("close");
            animator.SetTrigger("open");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
