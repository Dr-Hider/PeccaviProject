using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SoundManager musicManager;
    SoundManager sfxManager;
    public TextMeshProUGUI versionText;

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("musicManager").GetComponent<SoundManager>();
        sfxManager = GameObject.FindGameObjectWithTag("sfxManager").GetComponent<SoundManager>();
        versionText.text = $"Vesrion: {Application.version}";
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SaveSettings()
    {
        int musicVolume = musicManager.ASV;
        int sfxVolume = sfxManager.ASV;

        PlayerPrefs.SetInt("musicVolume", musicVolume);
        PlayerPrefs.SetInt("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}
