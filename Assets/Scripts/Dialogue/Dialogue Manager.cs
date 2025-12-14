using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static string JsonPath { get; set; } // A property to get JSON file
    public static int StringNumber { get; set; } // A property of current string in dialogue
    List<Dictionary<string, string>> data; // List of all dialogue strings
    public TextMeshProUGUI nameText; // Text field for the speaker's name
    public TextMeshProUGUI dialogueText; // Text field for a dialogue text
    public SpriteRenderer background; // Background sprite

    public GameObject mainPanel; // Panel which contains dialogue window and under menu
    public GameObject choicePanel; // Panel which contains choice
    public TextMeshProUGUI choice1Text; // Text field for choice 1
    public TextMeshProUGUI choice2Text; // Text field for choice 2

    SoundManager musicManager; // Music Manager object
    SoundManager sfxManager; // SFX Manager object

    // Setting start configuration
    void Awake()
    {
        JsonPath = SaveData.JsonPath;
        StringNumber = SaveData.StringNumber;
        data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(Resources.Load<TextAsset>($"JSON/{JsonPath}").text);
    }

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("musicManager").GetComponent<SoundManager>();
        sfxManager = GameObject.FindGameObjectWithTag("sfxManager").GetComponent<SoundManager>();

        OnStringChange();
    }

    // Method for changing JSON file
    void UpdateJSON()
    {
        data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(Resources.Load<TextAsset>($"JSON/{JsonPath}").text);
        StringNumber = 0;
    }

    // Method which called on string change
    void OnStringChange()
    {
        try
        {
            // If current string is the last in current JSON file
            if (StringNumber == data.Count - 1)
            {
                // If the next string is a choice
                if (data[StringNumber].ContainsKey("choice"))
                {
                    mainPanel.SetActive(false);
                    choicePanel.SetActive(true);
                    choice1Text.text = data[StringNumber]["choice1string"];
                    choice2Text.text = data[StringNumber]["choice2string"];
                }

                // If the next string is an ending
                if (data[StringNumber].ContainsKey("ending"))
                {
                    EndingParams.EndingName = data[StringNumber]["endingname"];
                    EndingParams.EndingDescription = data[StringNumber]["endingdescription"];
                    musicManager.OnChangeAudio(Resources.Load<AudioClip>("Music/Red Queens Lullaby"));
                    if (musicManager.Mute)
                        musicManager.Mute = false;
                    SceneManager.LoadScene("Ending");
                }

                // If the next string is an another scene
                if (data[StringNumber].ContainsKey("switchscene"))
                {
                    SaveData.Scene = data[StringNumber]["scenename"];
                    SaveData.JsonPath = data[StringNumber]["path"];
                    SaveData.StringNumber = 0;
                    SceneManager.LoadScene(SaveData.Scene);
                }

                return;
            }

            // Setting the text fields
            nameText.text = data[StringNumber]["name"];
            dialogueText.text = data[StringNumber]["text"];

            // Setting the background
            if (data[StringNumber]["image"] == "")
                background.enabled = false;
            else if (background.sprite.name != data[StringNumber]["image"])
            {
                background.sprite = Resources.Load<Sprite>($"Images/{data[StringNumber]["image"]}");
                if (!background.enabled)
                    background.enabled = true;

                // Unlocking the image in gallery
                PlayerPrefs.SetInt(background.sprite.name, 1);
                PlayerPrefs.Save();
            }

            // Setting the music clip
            if (data[StringNumber]["music"] == "")
                musicManager.Mute = true;
            else if (musicManager.CurrentClip.name != data[StringNumber]["music"])
            {
                musicManager.OnChangeAudio(Resources.Load<AudioClip>($"Music/{data[StringNumber]["music"]}"));
                if (musicManager.Mute == true)
                    musicManager.Mute = false;
            }

            // Setting the sound
            if (data[StringNumber]["sound"] != "")
            {
                sfxManager.OnChangeAudio(Resources.Load<AudioClip>($"Sounds/{data[StringNumber]["sound"]}"));
            }
        }
        catch
        {
            if (StringNumber < 0)
                StringNumber = 0;
            if (StringNumber > data.Count - 1)
                StringNumber = data.Count - 1;
        }

    }

    // Method to change the string to the next
    public void Forward()
    {
        StringNumber++;
        OnStringChange();
    }

    // Method to change the string to the previous
    public void Back()
    {
        StringNumber--;
        OnStringChange();
    }

    // Method which called on choice made
    public void OnChoice(int choice)
    {
        sfxManager.OnChangeAudio(Resources.Load<AudioClip>($"Sounds/OnChoice")); // Play sound of choice
        switch (choice)
        {
            // Setting a new path to JSON file
            case 1:
                JsonPath = data[StringNumber]["choice1path"];
                break;
            case 2:
                JsonPath = data[StringNumber]["choice2path"];
                break;
        }
        UpdateJSON();
        OnStringChange();
    }
}
