using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class UIPanels : MonoBehaviour
{
    private bool toggle;
    private bool controlstoggle;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject controlPanel;
    [SerializeField] FirstPersonControls firstPersonControls;
    public Canvas ObjectiveCanvas;
    private Controls playerInput;
    public AudioSource PanelOpenCloseSFX;


    private void OnEnable()
    {
        // Initialize the playerInput as a class-level variable
        playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the pause event
        playerInput.Player.Pause.performed += ctx => PauseGame();
    }

    private void OnDisable()
    {
        // Unsubscribe from the pause event to avoid multiple calls
        if (playerInput != null)
        {
            playerInput.Player.Pause.performed -= ctx => PauseGame();

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
    public void PauseGame()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            Debug.Log("PanelOff");
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
            PanelOpenCloseSFX.Play();
            ObjectiveCanvas.enabled = true;
            firstPersonControls.enabled = true;
            firstPersonControls.crosshair.enabled = true;

        }

        if (toggle)
        {
            Debug.Log("PanelOn");
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            PanelOpenCloseSFX.Play();
            ObjectiveCanvas.enabled = false;
            firstPersonControls.enabled = false;
            firstPersonControls.crosshair.enabled = false;
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
