using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private FirstPersonControls firstPersonControls;
    [Header("HUD Settings")]
    [Space(5)]
    public TextMeshProUGUI LibClueText;
    public TextMeshProUGUI LibStoryNote;
    public TextMeshProUGUI LibKeysText;
    public int LibraryClueCount = 0;
    public int LibNoteCount = 0;
    public int LibraryKeyCount = 0;
    public GameObject[] HUDElements;

    public TextMeshProUGUI HellClueText;
    public TextMeshProUGUI HellStoryNote;
    public TextMeshProUGUI HellKeysText;
    public int HellClueCount = 0;
    public int HellNoteCount = 0;
    public int HllKeyCount = 0;
    
    public TextMeshProUGUI HeavenClueText;
    public TextMeshProUGUI HeavenStoryNote;
    public TextMeshProUGUI HeavenKeysText;
    public int HeavenClueCount = 0;
    public int HeavenNoteCount = 0;
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
        LibClueText.text = LibraryClueCount + "/1";
        LibStoryNote.text = LibNoteCount + "/3";
        LibKeysText.text = LibraryKeyCount + "/1";

        HellClueText.text = HellClueCount + "/1";
        HellStoryNote.text = HellNoteCount + "/2";
        HellKeysText.text = HllKeyCount + "/1";
        /*
        HeavenClueText.text = HeavenClueCount + "/1";
        HeavenStoryNote.text = HeavenNoteCount + "/3";
        HeavenKeysText.text = HeavenKeyCount + "/1";*/

    }
}
