using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject mainPanel;
    public GameObject pausePanel;
    public GameObject choicePanel;
    public GameObject unhideButton;

    public bool Paused { get; set; }
    public bool Hidden { get; set; }

    void Update()
    {
        if (Hidden && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Hidden = !Hidden;
            mainPanel.SetActive(!mainPanel.activeSelf);
            unhideButton.SetActive(!unhideButton.activeSelf);
            return;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame && (mainPanel.activeSelf || pausePanel.activeSelf))
        {
            Paused = !Paused;
            mainPanel.SetActive(!mainPanel.activeSelf);
            pausePanel.SetActive(!pausePanel.activeSelf);
        }

        if (Paused) return;

        if (Keyboard.current.dKey.wasPressedThisFrame ||
            Keyboard.current.rightArrowKey.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame)
                dialogueManager.Forward();

        if (Keyboard.current.aKey.wasPressedThisFrame ||
            Keyboard.current.leftArrowKey.wasPressedThisFrame)
                dialogueManager.Back();
    }
}
