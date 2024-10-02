using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject letterUI;
    public MeshRenderer letterMesh;
    

    private bool toggle;
    private FirstPersonControls firstPerson;

    
    // Start is called before the first frame update
    public void NoteOpenClose()
    {
        toggle = !toggle;   
        if(toggle == false)
        {
            letterUI.SetActive(false);
            letterMesh.enabled = true;
            //firstPerson.moveSpeed = 6.4f;
            //firstPerson.lookSpeed = 0.62f;
        }

        if (toggle == true)
        {
            letterUI.SetActive(true);
            letterMesh.enabled = false;
            firstPerson.moveSpeed = 0;
            firstPerson.lookSpeed = 0;
        }
    }

  
}
