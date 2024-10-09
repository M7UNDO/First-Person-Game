using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    
    // Start is called before the first frame update

    private void OnEnable()
    {
        // Create a new instance of the input actions
        var playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();
       
        playerInput.Player.Pause.performed += ctx => Pause();

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
            
            

        }

        if (toggle)
        {
            
            pausePanel.SetActive(true);
            firstPersonControls.lookSpeed = 0f;
            firstPersonControls.moveSpeed = 0f;
            firstPersonControls.crosshair.enabled = false;
            ObjectiveCanvas.enabled = false;
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
