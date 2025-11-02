using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static int _counter;

    AudioSource audioSource;
    public string type;

    public int ASV
    {
        get { return (int)(audioSource.volume * 100); }
        set { audioSource.volume = value / 100f; }

    }

    void Awake()
    {
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
        ASV = PlayerPrefs.GetInt($"{type}Volume", 100);
    }
}
