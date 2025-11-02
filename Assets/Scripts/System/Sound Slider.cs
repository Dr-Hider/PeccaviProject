using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    Slider slider;
    SoundManager soundManager;
    public TextMeshProUGUI valueText;
    public string type;

    void Start()
    {
        slider = GetComponent<Slider>();
        soundManager = GameObject.FindGameObjectWithTag($"{type}Manager").GetComponent<SoundManager>();
        slider.value = soundManager.ASV;
        valueText.text = soundManager.ASV.ToString();
    }

    public void OnChangeValue()
    {
        soundManager.ASV = (int)slider.value;
        valueText.text = slider.value.ToString();
    }
}
