using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static int _counter; // Creating a variable to control a number of objects

    AudioSource audioSource;
    public string type; // Type of Audio Source object (Music or SFX)

    // A property to get and set the volume
    public int ASV
    {
        get { return (int)(audioSource.volume * 100); }
        set { audioSource.volume = value / 100f; }
    }

    public AudioClip CurrentClip
    {
        get { return audioSource.clip; }
        private set { audioSource.clip = value; }
    }

    public bool Mute
    {
        get { return audioSource.mute; }
        set { audioSource.mute = value; }
    }

    void Awake()
    {
        // Singleton
        if (_counter < 2)
        {
            _counter += 1;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        ASV = PlayerPrefs.GetInt($"{type}Volume", 100); // Getting saved settings
    }

    // Method to change the audio clip
    public void OnChangeAudio(AudioClip audioClip)
    {
        audioSource.Stop();
        CurrentClip = audioClip;
        audioSource.Play();
    }
}
