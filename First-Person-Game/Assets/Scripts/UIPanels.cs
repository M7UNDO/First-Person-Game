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
    FirstPersonControls firstPersonControls;
    [SerializeField] GameObject player;
    private float move;
    private float look;
    public Canvas ObjectiveCanvas;
    private Controls playerInput;

    // Start is called before the first frame update

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
        
        firstPersonControls = player.GetComponent<FirstPersonControls>();
        firstPersonControls.lookSpeed = look;
        firstPersonControls.moveSpeed = move;
        

        toggle = !toggle;
        if (toggle == false)
        {
            pausePanel.SetActive(false);
            firstPersonControls.lookSpeed = 0.62f;
            firstPersonControls.moveSpeed = 6.4f;
            firstPersonControls.crosshair.enabled = true;
            ObjectiveCanvas.enabled = true;
            //Time.timeScale = 1.0f;



        }

        if (toggle)
        {
            
            pausePanel.SetActive(true);
            firstPersonControls.lookSpeed = 0f;
            firstPersonControls.moveSpeed = 0f;
            firstPersonControls.crosshair.enabled = false;
            ObjectiveCanvas.enabled = false;
            //Time.timeScale = 0f;
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
