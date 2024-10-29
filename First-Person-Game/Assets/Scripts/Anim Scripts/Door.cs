using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private FirstPersonControls firstPersonControls;
    public bool toggle;
    [Header("DOOR ANIMATION SETTINGS")]
    [Space(3)]

    public Animator DoorAnimator;
    public AudioSource DoorOpen;
    public AudioSource DoorClose;
    public AudioSource DoorLocked;
    public bool isDoorLocked = true;
    


    [Header("DRAWER ANIMATION SETTINGS")]
    [Space(3)]

    public Animator DrawerAnimator;

    [Header("CABINET ANIMATION SETTINGS")]
    [Space(3)]

    public Animator cabinetAnimator;

    //Method referenced: OpenClose()
    //Title: How to Make Doors in Unity-Unity C# Tutorial
    //Author: Omogonix
    //Date: 3 November 2023
    //Availability: https://youtu.be/wzNykqSPa0M?si=VhTGdgftZh2k-Q3Z

    public void DoorOpenClose()
    {
        if (isDoorLocked)  // Check if the door is locked
        {
            DoorLocked.Play();
            Debug.Log("The door is locked.");
            return;
        }

        toggle = !toggle;
        if(toggle == false)
        {
            DoorAnimator.ResetTrigger("open");
            DoorAnimator.SetTrigger("close");
            DoorClose.Play();
        }

        if (toggle)
        {
            DoorAnimator.ResetTrigger("close");
            DoorAnimator.SetTrigger("open");
            DoorOpen.Play();
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

    public void CabinetOpenClose()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            cabinetAnimator.ResetTrigger("CabinetOpen");
            cabinetAnimator.SetTrigger("CabinetClose");
        }

        if (toggle)
        {
            cabinetAnimator.ResetTrigger("CabinetClose");
            cabinetAnimator.SetTrigger("CabinetOpen");
        }
    }

    public void UnlockDoor() => isDoorLocked = false;


    
}
