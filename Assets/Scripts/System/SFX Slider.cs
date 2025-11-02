using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    Slider slider;
    SFXManager sfxManager;
    public TextMeshProUGUI valueText;

    void Start()
    {
        slider = GetComponent<Slider>();
        sfxManager = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<SFXManager>();
        slider.value = sfxManager.ASV;
        valueText.text = sfxManager.ASV.ToString();
    }

    public void ChangeValue()
    {
        sfxManager.ASV = (int)slider.value;
        valueText.text = slider.value.ToString();
    }
}
