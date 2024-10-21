using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private FirstPersonControls firstPersonControls;
    [Header("HUD Settings")]
    [Space(5)]
   
    public TextMeshProUGUI LibKeysText;
  
    public int LibraryKeyCount = 0;
   

    public TextMeshProUGUI HellKeysText;
 
    public int HllKeyCount = 0;
    

    public TextMeshProUGUI HeavenKeysText;
  
    public int HeavenKeyCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HUDDisplay();
    }

    private void HUDDisplay()
    {
        
        LibKeysText.text = LibraryKeyCount + "/1";

        
        HellKeysText.text = HllKeyCount + "/1";
        
        
        HeavenKeysText.text = HeavenKeyCount + "/1";

    }
}
