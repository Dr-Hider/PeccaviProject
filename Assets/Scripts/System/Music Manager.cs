using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager _instance;

    AudioSource audioSource;
    public int ASV
    {
        get { return (int)(audioSource.volume*100); }
        set { audioSource.volume = value/100f; }

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
        ASV = PlayerPrefs.GetInt("musicVolume", 100);
    }

    public void SaveValue()
    {
        PlayerPrefs.SetInt("musicVolume", ASV);
        PlayerPrefs.Save();
    }
}
