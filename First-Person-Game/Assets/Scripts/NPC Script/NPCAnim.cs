using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnim : MonoBehaviour
{
    private FirstPersonControls firstPersonControls;
    public bool toggle;
    public Animator NPCAnimator;
    public AudioSource TalkSfx;
    public AudioSource IdleSfx;
    public GameObject PanelTxt1;
    public GameObject PanelTxt2;

    public void NPC()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            NPCAnimator.ResetTrigger("Idle");
            NPCAnimator.SetTrigger("talk");
            Debug.Log("Off");
            
            //DoorClose.Play();
        }

        if (toggle)
        {
            NPCAnimator.ResetTrigger("talk");
            NPCAnimator.SetTrigger("Idle");
            Debug.Log("On");
            StartCoroutine(TextDisplay());
            //DoorOpen.Play();
        }
    }

    IEnumerator TextDisplay()
    {
        PanelTxt1.SetActive(true);
        yield return new WaitForSeconds(2f);
        PanelTxt1.SetActive(false);
        PanelTxt2.SetActive(true);
        yield return new WaitForSeconds(2f);
        PanelTxt2.SetActive(false);

    }



}

