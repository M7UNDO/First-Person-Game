using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool toggle;
    public Animator animator;


    //Method referenced: OpenClose()
    //Title: How to Make Doors in Unity-Unity C# Tutorial
    //Author: Omogonix
    //Date: 3 November 2023
    //Availability: https://youtu.be/wzNykqSPa0M?si=VhTGdgftZh2k-Q3Z

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
