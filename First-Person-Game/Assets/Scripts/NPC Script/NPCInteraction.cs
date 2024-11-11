using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public Animator npcAnimator;         // Animator for NPC animations
    public GameObject dialoguePanel;     // UI panel for dialogue display
    public TextMeshProUGUI dialogueText;// Text component to show dialogue text
    public Button continueButton;        // Button to move to the next dialogue line
    public string[] dialogueLines;       // Array of dialogue lines
    private int dialogueIndex = 0;       // Tracks the current dialogue line index
    private bool isInteracting = false;  // Tracks if interaction is active
    public GameObject Wizard;
    public FirstPersonControls firstPeronControls;

    // Start interaction when called from the player script
    public void StartInteraction()
    {
        if (!isInteracting)  // Only start if not already interacting
        {
            firstPeronControls.SetPlayerMovement(false);
            isInteracting = true;
            dialogueIndex = 0;  // Reset dialogue index
            npcAnimator.SetTrigger("talk");  // Trigger talking animation
            ShowDialogue();  // Start showing the first dialogue line
        }
    }

    // Displays the current dialogue line and hides continue button until delay is over
    private void ShowDialogue()
    {
        if (dialogueIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[dialogueIndex]; // Set the dialogue text
            dialoguePanel.SetActive(true);                    // Show the dialogue panel
            continueButton.gameObject.SetActive(false);       // Hide continue button
            StartCoroutine(ShowContinueButtonAfterDelay());   // Wait before showing button
        }
        else
        {
            EndInteraction();  // End interaction if no more dialogue
        }
    }

    // Coroutine to delay the display of the continue button
    private IEnumerator ShowContinueButtonAfterDelay()
    {
        yield return new WaitForSeconds(2f);  // Wait 2 seconds
        continueButton.gameObject.SetActive(true);  // Show continue button
        continueButton.onClick.AddListener(NextDialogue);  // Set listener for next dialogue
    }

    // Progress to the next dialogue line or end interaction if finished
    private void NextDialogue()
    {
        continueButton.onClick.RemoveListener(NextDialogue);  // Remove previous listener
        dialogueIndex++;  // Move to the next line
        ShowDialogue();   // Show the next dialogue line
    }

    // Ends interaction by hiding dialogue, returning to idle, and fading out NPC
    private void EndInteraction()
    {
        firstPeronControls.SetPlayerMovement(true);
        dialoguePanel.SetActive(false);  // Hide dialogue panel
        npcAnimator.SetTrigger("Idle");  // Trigger idle animation
        StartCoroutine(FadeOutNPC());    // Fade out NPC after delay
    }

    // Coroutine to fade out the NPC and reset interaction state
    private IEnumerator FadeOutNPC()
    {
        yield return new WaitForSeconds(2f);  // Wait 2 seconds before hiding
        Wizard.SetActive(false);
        continueButton.gameObject.SetActive(false);// Deactivate NPC
        isInteracting = false;                // Reset interaction state
    }
}
