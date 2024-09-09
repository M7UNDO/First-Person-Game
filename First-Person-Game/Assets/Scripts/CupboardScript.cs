using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardScript : MonoBehaviour
{

    [Header("LEFT CUPBOARD ANIMATION SETTINGS")]
    [Space(5)]
    private bool toggle;
    public Animator animator;

    [Header("RIGHT CUPBOARD ANIMATION SETTINGS")]
    [Space(5)]
    public Animator _animator;
    // Start is called before the first frame update
    
    public void LeftDoor()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            animator.ResetTrigger("LeftOpen");
            animator.SetTrigger("LeftClose");
        }

        if (toggle)
        {
            animator.ResetTrigger("LeftClose");
            animator.SetTrigger("LeftOpen");
        }
    }

    public void RightDoor()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            _animator.ResetTrigger("RightOpen");
            _animator.SetTrigger("RightClose");
        }

        if (toggle)
        {
            _animator.ResetTrigger("RightClose");
            _animator.SetTrigger("RightOpen");
        }
    }
}
