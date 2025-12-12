using System;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    SaveData saveData;

    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;
    public TextMeshProUGUI slot1LoadText;
    public TextMeshProUGUI slot2LoadText;
    public TextMeshProUGUI slot3LoadText;
    public TextMeshProUGUI slot1SaveText;
    public TextMeshProUGUI slot2SaveText;
    public TextMeshProUGUI slot3SaveText;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
            saveData = new SaveData();

        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save001.json")))
        {
            slot1Button.interactable = true;
            DateTime dateRaw = File.GetLastWriteTime(Path.Combine(Application.persistentDataPath, $"Save001.json"));
            string date = $"{dateRaw.Day}.{dateRaw.Month}.{dateRaw.Year.ToString().Substring(2)} - {dateRaw.Hour}:{dateRaw.Minute}";
            slot1LoadText.text = date;
            if (SceneManager.GetActiveScene().name != "Main Menu")
                slot1SaveText.text = date;
        }

        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save002.json")))
        {
            slot2Button.interactable = true;
            DateTime dateRaw = File.GetLastWriteTime(Path.Combine(Application.persistentDataPath, $"Save002.json"));
            string date = $"{dateRaw.Day}.{dateRaw.Month}.{dateRaw.Year.ToString().Substring(2)} - {dateRaw.Hour}:{dateRaw.Minute}";
            slot2LoadText.text = date;
            if (SceneManager.GetActiveScene().name != "Main Menu")
                slot2SaveText.text = date;
        }

        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save003.json")))
        {
            slot3Button.interactable = true;
            DateTime dateRaw = File.GetLastWriteTime(Path.Combine(Application.persistentDataPath, $"Save003.json"));
            string date = $"{dateRaw.Day}.{dateRaw.Month}.{dateRaw.Year.ToString().Substring(2)} - {dateRaw.Hour}:{dateRaw.Minute}";
            slot3LoadText.text = date;
            if (SceneManager.GetActiveScene().name != "Main Menu")
                slot3SaveText.text = date;
        }

    }

    public void New()
    {
        SceneManager.LoadScene(SaveData.Scene);
    }

    public void Load(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"Save00{slot}.json");
        string json = File.ReadAllText(path);
        saveData = JsonConvert.DeserializeObject<SaveData>(json);
        SceneManager.LoadScene(SaveData.Scene);
    }

    public void Save(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"Save00{slot}.json");
        string scene = SceneManager.GetActiveScene().name;
        string jsonPath = DialogueManager.JsonPath;
        int stringNumber = DialogueManager.StringNumber;
        saveData = new SaveData(scene, jsonPath, stringNumber);
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
