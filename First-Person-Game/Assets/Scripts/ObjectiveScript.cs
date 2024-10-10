using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    [SerializeField] private GameObject locationObjectives;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisplayUI());
            print("Hi");
        }
        else
        {
            locationObjectives.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            locationObjectives.SetActive(false);
            print("Hi");
        }
    }

    IEnumerator DisplayUI()
    {
        yield return new WaitForSeconds(1.3f);
        locationObjectives.SetActive(true);
        

    }

}
