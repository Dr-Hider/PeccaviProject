using UnityEngine;

public class SFXManager : MonoBehaviour
{
    static SFXManager _instance;

    AudioSource audioSource;
    public int ASV
    {
        get { return (int)(audioSource.volume * 100); }
        set { audioSource.volume = value / 100f; }

    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        ASV = PlayerPrefs.GetInt("sfxVolume", 100);
    }

    public void SaveValue()
    {
        PlayerPrefs.SetInt("sfxVolume", ASV);
        PlayerPrefs.Save();
    }
}
