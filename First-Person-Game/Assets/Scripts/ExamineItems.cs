using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExamineItems : MonoBehaviour
{
   
    public string itemDescription = "insert text here";
    public TMP_Text itemDescriptionText;
    

    // Start is called before the first frame update
    void Start()
    {
        itemDescriptionText.text = itemDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
