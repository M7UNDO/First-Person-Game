using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIPanels : MonoBehaviour
{
    private bool toggle;
    private bool controlstoggle;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject controlPanel;
    private FirstPersonControls firstPersonControls;
    [SerializeField] GameObject player;
    public Canvas ObjectiveCanvas;
    private Controls playerInput;


    private void OnEnable()
    {
        // Initialize the playerInput as a class-level variable
        playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the pause event
        playerInput.Player.Pause.performed += ctx => Pause();
    }

    private void OnDisable()
    {
        // Unsubscribe from the pause event to avoid multiple calls
        if (playerInput != null)
        {
            playerInput.Player.Pause.performed -= ctx => Pause();

            // Disable the input actions
            playerInput.Player.Disable();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Scene restarted");
        Time.timeScale = 1f;
    }

    public void LoadGame()
    {
       
        SceneManager.LoadScene("Level Scene");
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Pause()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            firstPersonControls.lookSpeed = 6.4f;
            firstPersonControls.moveSpeed = 0.62f;
            pausePanel.SetActive(false);
            firstPersonControls.crosshair.enabled = true;
            ObjectiveCanvas.enabled = true;
            //Time.timeScale = 1.0f;

        }

        if (toggle)
        {
            firstPersonControls.lookSpeed = 0f;
            firstPersonControls.moveSpeed = 0f;
            pausePanel.SetActive(true);
            firstPersonControls.crosshair.enabled = false;
            ObjectiveCanvas.enabled = false;
            //Time.timeScale = 0f;
        }

    }

    private void SetPlayerMovement(bool isActive)
    {
        if (isActive)
        {
            firstPersonControls.moveSpeed = 6.4f;
            firstPersonControls.lookSpeed = 0.62f;
        }
        else
        {
            firstPersonControls.lookSpeed = 0f;
            firstPersonControls.moveSpeed = 0f;
        }
    }


    public void ControlPanel()
    {
        controlstoggle = !controlstoggle;

        if (controlstoggle == false)
        {
            controlPanel.SetActive(false);
            

        }

        if (controlstoggle)
        {
            
            controlPanel.SetActive(true);
        }

    }
}
