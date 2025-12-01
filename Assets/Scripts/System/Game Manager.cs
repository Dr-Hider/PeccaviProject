using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundManager musicManager; // Music Manager object
    SoundManager sfxManager; // SFX Manager object
    public TextMeshProUGUI versionText; // Game version text

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("musicManager").GetComponent<SoundManager>();
        sfxManager = GameObject.FindGameObjectWithTag("sfxManager").GetComponent<SoundManager>();
        versionText.text = $"Vesrion: {Application.version}"; // Setting the current game version to the game vesrion text field
    }

    // Method to leave the game
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Method to save settings
    public void SaveSettings()
    {
        int musicVolume = musicManager.ASV;
        int sfxVolume = sfxManager.ASV;

        PlayerPrefs.SetInt("musicVolume", musicVolume);
        PlayerPrefs.SetInt("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    // Method to start new game
    public void NewGame()
    {
        SceneManager.LoadScene("Chapter 1 Introduction");
    }
}
