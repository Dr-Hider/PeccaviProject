using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // Buttons to set them interactible or not
    public Button slot1Button; // Slot 1 in load menu
    public Button slot2Button; // Slot 2 in load menu
    public Button slot3Button; // Slot 3 in load menu

    // Buttons to hide or unhide them
    public GameObject slot1DeleteButton; // Slot 1 delete in load menu
    public GameObject slot2DeleteButton; // Slot 2 delete in load menu
    public GameObject slot3DeleteButton; // Slot 3 delete in load menu
    public GameObject slot1SaveDeleteButton; // Slot 1 delete in save menu
    public GameObject slot2SaveDeleteButton; // Slot 2 delete in save menu
    public GameObject slot3SaveDeleteButton; // Slot 3 delete in save menu

    // Text fields to display save info
    public TextMeshProUGUI slot1LoadText; // Slot 1 text in load menu
    public TextMeshProUGUI slot2LoadText; // Slot 2 text in load menu
    public TextMeshProUGUI slot3LoadText; // Slot 3 text in load menu
    public TextMeshProUGUI slot1SaveText; // Slot 1 text in save menu
    public TextMeshProUGUI slot2SaveText; // Slot 2 text in save menu
    public TextMeshProUGUI slot3SaveText; // Slot 3 text in save menu

    public TextMeshProUGUI versionText; // Game version text
    void Start()
    {
        // Setting the current game version to the game vesrion text field
        if (SceneManager.GetActiveScene().name == "Main Menu")
            versionText.text = $"Vesrion: {Application.version}";

        // Setting save info into the text fields if save exists
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save001.txt")))
            SaveTextSet(1);
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save002.txt")))
            SaveTextSet(2);
        if (File.Exists(Path.Combine(Application.persistentDataPath, $"Save003.txt")))
            SaveTextSet(3);
    }

    // Method to set save info to the text fields
    public void SaveTextSet(int slot)
    {
        switch (slot)
        {
            // Slot 1
            case 1:
                slot1LoadText.text = GetSaveText(slot); // Update button text in load menu
                slot1Button.interactable = true; // Make button in load menu interactive
                slot1DeleteButton.SetActive(true); // Make delete button in load menu active
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    slot1SaveText.text = GetSaveText(slot); // Update button text in save menu
                    slot1SaveDeleteButton.SetActive(true); // Make delete button in save menu active
                }
                break;

            // Slot 2
            case 2:
                slot2LoadText.text = GetSaveText(slot); // Update button text in load menu
                slot2Button.interactable = true; // Make button in load menu interactive
                slot2DeleteButton.SetActive(true); // Make delete button in load menu active
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    slot2SaveText.text = GetSaveText(slot); // Update button text in save menu
                    slot2SaveDeleteButton.SetActive(true); // Make delete button in save menu active
                }
                break;

            // Slot 3
            case 3:
                slot3LoadText.text = GetSaveText(slot); // Update button text in load menu
                slot1Button.interactable = true; // Make button in load menu interactive
                slot3DeleteButton.SetActive(true); // Make delete button in load menu active
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    slot3SaveText.text = GetSaveText(slot); // Update button text in save menu
                    slot3SaveDeleteButton.SetActive(true); // Make delete button in save menu active
                }                        
                break;
        }
    }

    // Method to clear save info in the text fields
    public void DefaultTextSet(int slot)
    {
        switch (slot)
        {
            // Slot 1
            case 1:
                slot1LoadText.text = "Пустой слот"; // Update button text in load menu
                slot1Button.interactable = false; // Make button in load menu uninteractive
                slot1DeleteButton.SetActive(false); // Make delete button in load menu inactive
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    slot1SaveText.text = "Пустой слот"; // Update button text in save menu
                    slot1SaveDeleteButton.SetActive(false); // Make delete button in save menu inactive
                }
                break;

            // Slot 2
            case 2:
                slot2LoadText.text = "Пустой слот"; // Update button text in load menu
                slot2Button.interactable = false; // Make button in load menu uninteractive
                slot2DeleteButton.SetActive(false); // Make delete button in load menu inactive
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    slot2SaveText.text = "Пустой слот"; // Update button text in save menu
                    slot2SaveDeleteButton.SetActive(false); // Make delete button in save menu inactive
                }
                break;

            // Slot 3
            case 3:
                slot3LoadText.text = "Пустой слот"; // Update button text in load menu
                slot3Button.interactable = false; // Make button in load menu uninteractive
                slot3DeleteButton.SetActive(false); // Make delete button in load menu inactive
                if (SceneManager.GetActiveScene().name != "Main Menu")
                {
                    slot3SaveText.text = "Пустой слот"; // Update button text in save menu
                    slot3SaveDeleteButton.SetActive(false); // Make delete button in save menu inactive
                }
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
