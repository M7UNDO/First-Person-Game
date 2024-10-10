using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject controlPanel;
    private bool controlstoggle;
    // Start is called before the first frame update
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
