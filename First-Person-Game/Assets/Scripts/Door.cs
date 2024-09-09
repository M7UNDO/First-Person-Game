using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("DOOR ANIMATION SETTINGS")]
    [Space(5)]
    private bool toggle;
    public Animator DoorAnimator;


    [Header("DRAWER ANIMATION SETTINGS")]
    [Space(5)]
    public Animator DrawerAnimator;


    //Method referenced: OpenClose()
    //Title: How to Make Doors in Unity-Unity C# Tutorial
    //Author: Omogonix
    //Date: 3 November 2023
    //Availability: https://youtu.be/wzNykqSPa0M?si=VhTGdgftZh2k-Q3Z

    public void DoorOpenClose()
    {
        toggle = !toggle;
        if(toggle == false)
        {
            DoorAnimator.ResetTrigger("open");
            DoorAnimator.SetTrigger("close");
        }

        if (toggle)
        {
            DoorAnimator.ResetTrigger("close");
            DoorAnimator.SetTrigger("open");
        }
    }

    public void DrawerOpenClose()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            DrawerAnimator.ResetTrigger("OpenDrawer");
            DrawerAnimator.SetTrigger("CloseDrawer");
        }

        if (toggle)
        {
            DrawerAnimator.ResetTrigger("CloseDrawer");
            DrawerAnimator.SetTrigger("OpenDrawer");
        }
    }


}
