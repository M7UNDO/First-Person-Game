using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExamineItems : MonoBehaviour
{
   
    public string itemDescription;
    public TMP_Text itemDescriptionText;
    

    // Start is called before the first frame update
    void Start()
    {
        itemDescriptionText.text = itemDescription; //a description of the bookshelf will popup if the Item Examination metion in the First Person Controls script is called on
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
