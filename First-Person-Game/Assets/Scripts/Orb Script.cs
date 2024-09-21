using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    [Header("ORB ANIMATION SETTINGS")]
    [Space(5)]

    private bool toggle;
    public Animator OrbAnimator;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OrbSpin()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            OrbAnimator.ResetTrigger("spin");
            OrbAnimator.SetTrigger("back");
            
        }

        if (toggle)
        {
            OrbAnimator.ResetTrigger("spin");
            OrbAnimator.SetTrigger("back");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
