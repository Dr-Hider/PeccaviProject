using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    Button openedImage; // Variable to keep the opened image
    public Sprite locker; // Locker icon
    public Image bigImage;

    void Awake()
    {
        // Unlocking unlocked images
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("imageButton");
        foreach (GameObject button in gameObjects)
        {
            if (PlayerPrefs.GetInt(button.name) == 0)
            {
                button.GetComponent<Button>().interactable = false;
                button.GetComponent<Button>().image.sprite = locker;
            }
        }
    }

    void Update()
    {
        if (bigImage.gameObject.activeSelf && Keyboard.current.anyKey.wasPressedThisFrame)
            CloseImage();
    }

    // Method to open an image
    public void OpenImage(Button button)
    {
        openedImage = button;
        button.interactable = false;
        bigImage.sprite = button.image.sprite;
        bigImage.gameObject.SetActive(true);
    }

    // Method to close the image
    public void CloseImage()
    {
        bigImage.gameObject.SetActive(false);
        openedImage.interactable = true;
    }

    // Method to return to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Method to lock all the images
    public void ResetImages()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("imageButton");
        foreach (GameObject button in gameObjects)
        {
            PlayerPrefs.SetInt(button.name, 0);
            PlayerPrefs.Save();
            if (PlayerPrefs.GetInt(button.name) == 0)
            {
                button.GetComponent<Button>().interactable = false;
                button.GetComponent<Button>().image.sprite = locker;
            }
        }
    }
}
