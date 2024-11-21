using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private FirstPersonControls firstPersonControls;
    [Header("HUD Settings")]
    [Space(5)]
   
    public TextMeshProUGUI LibKeysText;
    public int LibraryKeyCount = 0;
    public Image LibraryIcon;
    
   

    public TextMeshProUGUI HellKeysText;
    public int HllKeyCount = 0;
    public Image HellIcon;


    public TextMeshProUGUI HeavenKeysText;
    public int HeavenKeyCount = 0;
    public Image HeavenIcon;
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
            LibKeysText.color = new Color(84f / 255f, 175f / 255f, 75f / 255f, 1f); 
            LibraryIcon.color = new Color(84f / 255f, 175f / 255f, 75f / 255f, 1f);

        }

        HellKeysText.text = "Keys found: " + HllKeyCount + "/1";
        if (HllKeyCount >= 1)
        {
            HellKeysText.color = new Color(84f / 255f, 175f / 255f, 75f / 255f, 1f);
            HellIcon.color = new Color(84f / 255f, 175f / 255f, 75f / 255f, 1f);

        }

        HeavenKeysText.text = "Keys found: " + HeavenKeyCount + "/1";
        if (HeavenKeyCount >= 1)
        {
            HeavenKeysText.color = new Color(84f / 255f, 175f / 255f, 75f / 255f, 1f);
            HeavenIcon.color = new Color(84f / 255f, 175f / 255f, 75f / 255f, 1f);

        }

    }
}
