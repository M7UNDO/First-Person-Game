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
        
        LibKeysText.text = "Keys found: " + LibraryKeyCount + "/1";
        if(LibraryKeyCount >= 1)
        {
            LibKeysText.color = Color.green;
        }
        
        HellKeysText.text = "Keys found: " + HllKeyCount + "/1";
        if (HllKeyCount >= 1)
        {
            HellKeysText.color = Color.green;
        }

        HeavenKeysText.text = "Keys found: " + HeavenKeyCount + "/1";
        if (HeavenKeyCount >= 1)
        {
            HeavenKeysText.color = Color.green;
        }

    }
}
