using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SoundtrackManager : MonoBehaviour
{
    AudioSource audioSource;
    public Slider progressBar;
    public GameObject playButton; 
    public GameObject pauseButton;
    public TextMeshProUGUI playingText; // Text field which displays what soundtrack plays right now

    // A property to get and set the volume
    public int ASV
    {
        get { return (int)(audioSource.volume * 100); }
        set { audioSource.volume = value / 100f; }
    }

    public AudioClip Clip
    {
        get {  return audioSource.clip; }
        set
        {
            audioSource.Stop(); // Stop playing the current clip
            audioSource.clip = value; // Set a new clip
            progressBar.maxValue = audioSource.clip.length; // Set the max value of the progress bar
            pauseButton.SetActive(false);
            playButton.SetActive(true);

        }
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        progressBar.maxValue = audioSource.clip.length;
    }

    void Update()
    {
        progressBar.value = audioSource.time; // Changing time position on changin value of the progress bar
    }

    // Method to change the time position
    public void OnTimeChange()
    {
        audioSource.time = progressBar.value;
    }

    // Method to pause or unpause the clip
    public void OnStateChange()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }

    // Method to change the name of the current soundtrack
    public void OnNameChange(TextMeshProUGUI nameText)
    {
        playingText.text = "Сейчас играет: " + nameText.text;
    }

    // Method to return to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
