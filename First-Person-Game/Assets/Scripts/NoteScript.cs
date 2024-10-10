using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject letterUI;
    public MeshRenderer letterMesh;
    private FirstPersonControls firstPersonControls;
    private bool toggle;
    public void NoteOpenClose()
    {
        toggle = !toggle;   
        if(toggle == false)
        {
            letterUI.SetActive(false);
            letterMesh.enabled = true;
            
        }

        if (toggle == true)
        {
            letterUI.SetActive(true);
            letterMesh.enabled = false;
            

        }
    }

  
}
