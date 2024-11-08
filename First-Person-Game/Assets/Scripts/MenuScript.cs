using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject controlPanel;
    private bool controlstoggle;
    public GameObject Title;
    // Start is called before the first frame update
    public void ControlPanel()
    {
        controlstoggle = !controlstoggle;

        if (controlstoggle == false)
        {
            controlPanel.SetActive(false);
            Title.SetActive(true);


        }

        if (controlstoggle)
        {

            controlPanel.SetActive(true);
            Title.SetActive(false);
        }

    }
}
