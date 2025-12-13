using UnityEngine;
using UnityEngine.UI;

public class SoundtrackSlider : MonoBehaviour
{
    Slider slider;
    public SoundtrackManager soundtrackManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = soundtrackManager.ASV; // Setting the current volume value to the slider
    }

    // Method to change the volume
    public void OnChangeValue()
    {
        soundtrackManager.ASV = (int)slider.value;
    }
}
