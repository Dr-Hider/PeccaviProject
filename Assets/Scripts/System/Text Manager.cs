using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // Buttons to set them interactible or not
    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;

    // Text fields to display save info
    public TextMeshProUGUI slot1LoadText;
    public TextMeshProUGUI slot2LoadText;
    public TextMeshProUGUI slot3LoadText;
    public TextMeshProUGUI slot1SaveText;
    public TextMeshProUGUI slot2SaveText;
    public TextMeshProUGUI slot3SaveText;

    public TextMeshProUGUI versionText; // Game version text
    void Start()
    {
        // Setting the current game version to the game vesrion text field
        if (SceneManager.GetActiveScene().name == "Main Menu")
            versionText.text = $"Vesrion: {Application.version}";

        // Setting save info into the text fields if save exists
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save001.txt")))
        {
            slot1Button.interactable = true;
            SaveTextSet(1);
        }
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save002.txt")))
        {
            slot2Button.interactable = true;
            SaveTextSet(2);
        }
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save003.txt")))
        {
            slot3Button.interactable = true;
            SaveTextSet(3);
        }
    }

    // Method to set save info to the text fields
    public void SaveTextSet(int slot)
    {
        switch (slot)
        {
            case 1:
                slot1LoadText.text = GetSaveText(slot);
                if (SceneManager.GetActiveScene().name != "Main Menu")
                    slot1SaveText.text = GetSaveText(slot);
                break;
            case 2:
                slot2LoadText.text = GetSaveText(slot);
                if (SceneManager.GetActiveScene().name != "Main Menu")
                    slot2SaveText.text = GetSaveText(slot);
                break;
            case 3:
                slot3LoadText.text = GetSaveText(slot);
                if (SceneManager.GetActiveScene().name != "Main Menu")
                    slot3SaveText.text = GetSaveText(slot);
                break;
        }
    }

    // Method to get save info
    string GetSaveText(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"Save00{slot}.txt");

        // Getting date
        DateTime dateRaw = File.GetLastWriteTime(path);
        string day = Convert.ToInt32(dateRaw.Day) < 10 ? "0" + dateRaw.Day.ToString() : dateRaw.Day.ToString();
        string month = Convert.ToInt32(dateRaw.Month) < 10 ? "0" + dateRaw.Month.ToString() : dateRaw.Month.ToString();
        string year = dateRaw.Year.ToString().Substring(2);
        string hour = Convert.ToInt32(dateRaw.Hour) < 10 ? "0" + dateRaw.Hour.ToString() : dateRaw.Hour.ToString();
        string minute = Convert.ToInt32(dateRaw.Minute) < 10 ? "0" + dateRaw.Minute.ToString() : dateRaw.Minute.ToString();

        string date = $"{day}.{month}.{year} - {hour}:{minute}";

        string chapter = File.ReadAllText(path); // Getting chapter name

        return chapter+'\n'+date;
    }
}
