using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    [Header("ORB ANIMATION SETTINGS")]
    [Space(5)]

    private bool toggle;
    public Animator OrbAnimator;

    public void OrbSpin()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            OrbAnimator.ResetTrigger("spin");
            OrbAnimator.SetTrigger("back");
            
        }

        if (toggle == true)
        {
            OrbAnimator.ResetTrigger("back");
            OrbAnimator.SetTrigger("spin");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
