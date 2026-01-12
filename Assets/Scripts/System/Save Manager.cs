using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    SaveData saveData; // Save data object for serialize or deserialize

    public TextManager textManager; // Text manager object
    SoundManager musicManager; // Music Manager object

    // Translation of chapter names
    Dictionary<string, string> chapterNames = new Dictionary<string, string>()
    {
        { "Chapter 1 Introduction", "Глава 1\nВступление" },
        { "Chapter 1 Awaking", "Глава 1\nПробуждение" }
    };

    // Clear save data in main menu
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
            saveData = new SaveData();
    }

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("musicManager").GetComponent<SoundManager>();
    }

    // Method to start new game
    public void New()
    {
        SceneManager.LoadScene(SaveData.Scene);
    }

    // Method to load game
    public void Load(int slot)
    {
        // Getting save data
        string path = Path.Combine(Application.persistentDataPath, $"Save00{slot}.json");
        string json = File.ReadAllText(path);
        saveData = JsonConvert.DeserializeObject<SaveData>(json);
        SceneManager.LoadScene(SaveData.Scene);
    }

    // Method to save game
    public void Save(int slot)
    {
        // Setting save data
        string path = Path.Combine(Application.persistentDataPath, $"Save00{slot}");
        string scene = SceneManager.GetActiveScene().name;
        string jsonPath = DialogueManager.JsonPath;
        int stringNumber = DialogueManager.StringNumber;
        saveData = new SaveData(scene, jsonPath, stringNumber);
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText($"{path}.json", json);

        // Setting save info
        string info = chapterNames[SceneManager.GetActiveScene().name];
        File.WriteAllText($"{path}.txt", info);

        textManager.SaveTextSet(slot); // Update text fields
    }

    // Method to delete a saved game
    public void Delete(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"Save00{slot}");
        File.Delete($"{path}.json");
        File.Delete($"{path}.txt");

        textManager.DefaultTextSet(slot);
    }

    // Method to return to main menu
    public void MainMenu()
    {
        musicManager.OnChangeAudio(Resources.Load<AudioClip>("Music/Red Queens Lullaby"));
        if (musicManager.Mute)
            musicManager.Mute = false;
        SceneManager.LoadScene("Main Menu");
    }
}
