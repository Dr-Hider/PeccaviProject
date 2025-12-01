using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    Slider slider;
    SoundManager soundManager;
    public TextMeshProUGUI valueText; // Text that contains the volume value
    public string type; // Type of Audio Souce object (Music or SFX)

    void Start()
    {
        slider = GetComponent<Slider>();
        soundManager = GameObject.FindGameObjectWithTag($"{type}Manager").GetComponent<SoundManager>();
        slider.value = soundManager.ASV; // Setting the current volume value to the slider
        valueText.text = soundManager.ASV.ToString(); // Setting the current volume value to the volume value text field
    }

    // Method to change the volume
    public void OnChangeValue()
    {
        soundManager.ASV = (int)slider.value;
        valueText.text = slider.value.ToString();
    }
}
