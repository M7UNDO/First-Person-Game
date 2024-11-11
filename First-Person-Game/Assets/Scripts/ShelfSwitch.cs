using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfSwitch : MonoBehaviour
{

    [Header("LEVER ANIMATION SETTINGS")]
    [Space(5)]
    private bool toggle;
    public Animator animator;
    public AudioSource ShelfSlideSFX;

    public void Lever()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            animator.ResetTrigger("LeverOn");
            animator.SetTrigger("LeverOff");
            ShelfSlideSFX.Play();
            
        }

        if (toggle)
        {
            animator.ResetTrigger("LeverOff");
            animator.SetTrigger("LeverOn");
            ShelfSlideSFX.Play();
            
        }
    }

}
