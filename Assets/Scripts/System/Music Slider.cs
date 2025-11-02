using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    Slider slider;
    MusicManager musicManager;
    public TextMeshProUGUI valueText;

    void Start()
    {
        slider = GetComponent<Slider>();
        musicManager = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        slider.value = musicManager.ASV;
        valueText.text = musicManager.ASV.ToString();
    }

    public void ChangeValue()
    {
        musicManager.ASV = (int)slider.value;
        valueText.text = slider.value.ToString();
    }
}
