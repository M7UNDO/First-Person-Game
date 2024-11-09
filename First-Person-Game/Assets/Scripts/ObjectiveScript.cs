using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectiveScript : MonoBehaviour
{
    [SerializeField] private GameObject locationObjectives;
    [SerializeField] private GameObject objectivePanel;
    private bool toggle = true;
    private Controls playerInput;

   



    private void OnEnable()
    {
        // Initialize the playerInput as a class-level variable
        playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the pause event
        playerInput.Player.Objective.performed += ctx => ObjectiveOnOff();
    }

    private void OnDisable()
    {
        // Unsubscribe from the pause event to avoid multiple calls
        if (playerInput != null)
        {
            playerInput.Player.Objective.performed -= ctx => ObjectiveOnOff();

            // Disable the input actions
            playerInput.Player.Disable();
        }
    }

    private void ObjectiveOnOff()
    {
        toggle = !toggle;

        if (toggle)
        {
            objectivePanel.SetActive(true);
        }

        if(toggle == false)
        {
            
            objectivePanel.SetActive(false);

        }
        
    }

    private void OnTriggerEnter(Collider coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisplayUI());

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

        }

    }

    IEnumerator DisplayUI()
    {
        yield return new WaitForSeconds(1.3f);
        locationObjectives.SetActive(true);
        

    }

}
