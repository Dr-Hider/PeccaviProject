using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    public DialogueManager dialogueManager; // Dialogue manager object
    public GameObject mainPanel; // Panel which contains dialogue window and under menu
    public GameObject pausePanel; // Panel which contains pause menu
    public GameObject unhideButton; // Invisible button to unhide the interface

    public bool Paused { get; set; } // Bool variable to control pausing the game
    public bool Hidden { get; set; } // Bool variable to control hiding the interface

    void Update()
    {
        // Unhide
        if (Hidden && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Hidden = !Hidden;
            mainPanel.SetActive(!mainPanel.activeSelf);
            unhideButton.SetActive(!unhideButton.activeSelf);
            return;
        }

        // Unpause
        if (Keyboard.current.escapeKey.wasPressedThisFrame && (mainPanel.activeSelf || pausePanel.activeSelf))
        {
            Paused = !Paused;
            mainPanel.SetActive(!mainPanel.activeSelf);
            pausePanel.SetActive(!pausePanel.activeSelf);
        }

        if (Paused) return;

        // Next string
        if (Keyboard.current.dKey.wasPressedThisFrame ||
            Keyboard.current.rightArrowKey.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame)
                dialogueManager.Forward();

        // Previous string
        if (Keyboard.current.aKey.wasPressedThisFrame ||
            Keyboard.current.leftArrowKey.wasPressedThisFrame)
                dialogueManager.Back();
    }
}
