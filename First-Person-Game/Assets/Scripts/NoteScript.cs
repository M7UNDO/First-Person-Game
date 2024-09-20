using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject[] Notes;
    private bool toggle;
    void Start()
    {
        
    }

    public void NoteOpenClose()
    {
        foreach( GameObject note in Notes )
        {
            toggle = !toggle;
            if (toggle == false)
            {
               note.SetActive(false);
            }

            if (toggle)
            {
                note.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
