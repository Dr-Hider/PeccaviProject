using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static string JsonPath { get; set; } // A property to get JSON file
    public static int StringNumber { get; set; } // A property of current string in dialogue
    List<Dictionary<string, string>> data; // List of all dialogue strings
    public TextMeshProUGUI nameText; // Text field for the speaker's name
    public TextMeshProUGUI dialogueText; // Text field for a dialogue text
    public SpriteRenderer background;

    public GameObject mainPanel; // Panel which contains dialogue window and under menu
    public GameObject choicePanel; // Panel which contains choice
    public TextMeshProUGUI choice1Text; // Text field for choice 1
    public TextMeshProUGUI choice2Text; // Text field for choice 2

    // Setting start configuration
    void Awake()
    {
        JsonPath = SaveData.JsonPath;
        StringNumber = SaveData.StringNumber;
        data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(Resources.Load<TextAsset>($"JSON/{JsonPath}").text);
    }

    void Start()
    {
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
                // If the next action is a choice
                if (data[StringNumber].ContainsKey("choice"))
                {
                    mainPanel.SetActive(false);
                    choicePanel.SetActive(true);
                    choice1Text.text = data[StringNumber]["choice1string"];
                    choice2Text.text = data[StringNumber]["choice2string"];
                }
                return;
            }

            // Changing text fields and background
            nameText.text = data[StringNumber]["name"]; // Setting the speaker's name
            dialogueText.text = data[StringNumber]["text"]; // Setting the current dialogue string

            // Setting the background
            if (data[StringNumber]["image"] == "")
                background.sprite = null;
            else
                background.sprite = Resources.Load<Sprite>($"Images/{data[StringNumber]["image"]}");
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
