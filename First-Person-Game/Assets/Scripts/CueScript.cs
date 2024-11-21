using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueScript : MonoBehaviour
{
    public GameObject playerHint;
    public GameObject playerClue;
    public GameObject Trigger;

    private void OnTriggerEnter(Collider coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            StartCoroutine(HintDisplay());
        }
    }

    IEnumerator HintDisplay()
    {
        
        playerHint.SetActive(true);
        yield return new WaitForSeconds(3f);
        playerHint.SetActive(false);
        playerClue.SetActive(true);
        yield return new WaitForSeconds(2f);
        playerClue.SetActive(false);
        Trigger.SetActive(false);
    }
}
