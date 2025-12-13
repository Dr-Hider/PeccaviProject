using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundManager musicManager; // Music Manager object
    SoundManager sfxManager; // SFX Manager object

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("musicManager").GetComponent<SoundManager>();
        sfxManager = GameObject.FindGameObjectWithTag("sfxManager").GetComponent<SoundManager>();
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

    // Method to open soudtracks menu
    public void Soudtracks()
    {
        Destroy(musicManager.gameObject);
        Destroy(sfxManager.gameObject);
        SoundManager._counter = 0; // Setting counter of sound managers to zero
        SceneManager.LoadScene("Soundtracks");
    }
}
