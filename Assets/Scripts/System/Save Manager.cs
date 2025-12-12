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

        SaveTextSet(1);
        SaveTextSet(2);
        SaveTextSet(3);
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
        switch (slot)
        {
            case 1:
                slot1SaveText.text = GetSaveDate($"Save00{slot}.json");
                slot1LoadText.text = GetSaveDate($"Save00{slot}.json");
                break;
            case 2:
                slot2SaveText.text = GetSaveDate($"Save00{slot}.json");
                slot2LoadText.text = GetSaveDate($"Save00{slot}.json");
                break;
            case 3:
                slot3SaveText.text = GetSaveDate($"Save00{slot}.json");
                slot3LoadText.text = GetSaveDate($"Save00{slot}.json");
                break;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    string GetSaveDate(string fileName)
    {
        DateTime dateRaw = File.GetLastWriteTime(Path.Combine(Application.persistentDataPath, fileName));
        string day = Convert.ToInt32(dateRaw.Day) < 10 ? "0" + dateRaw.Day.ToString() : dateRaw.Day.ToString();
        string month = Convert.ToInt32(dateRaw.Month) < 10 ? "0" + dateRaw.Month.ToString() : dateRaw.Month.ToString();
        string year = dateRaw.Year.ToString().Substring(2);
        string hour = Convert.ToInt32(dateRaw.Hour) < 10 ? "0" + dateRaw.Hour.ToString() : dateRaw.Hour.ToString();
        string minute = Convert.ToInt32(dateRaw.Minute) < 10 ? "0" + dateRaw.Minute.ToString() : dateRaw.Minute.ToString();

        string date = $"{day}.{month}.{year} - {hour}:{minute}";
        return date;
    }

    void SaveTextSet(int slot)
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save00{slot}.json")))
        {
            switch (slot)
            {
                case 1:
                    slot1Button.interactable = true;
                    slot1LoadText.text = GetSaveDate($"Save00{slot}.json");
                    if (SceneManager.GetActiveScene().name != "Main Menu")
                        slot1SaveText.text = GetSaveDate($"Save00{slot}.json");
                    break;
                case 2:
                    slot2Button.interactable = true;
                    slot2LoadText.text = GetSaveDate($"Save00{slot}.json");
                    if (SceneManager.GetActiveScene().name != "Main Menu")
                        slot2SaveText.text = GetSaveDate($"Save00{slot}.json");
                    break;
                case 3:
                    slot3Button.interactable = true;
                    slot3LoadText.text = GetSaveDate($"Save00{slot}.json");
                    if (SceneManager.GetActiveScene().name != "Main Menu")
                        slot3SaveText.text = GetSaveDate($"Save00{slot}.json");
                    break;
            }
        }
    }
}
