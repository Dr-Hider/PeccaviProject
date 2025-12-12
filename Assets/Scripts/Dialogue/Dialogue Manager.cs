using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static string JsonPath { get; set; }
    public static int StringNumber { get; set; }
    List<Dictionary<string, string>> data;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public SpriteRenderer background;

    public GameObject mainPanel;
    public GameObject choicePanel;
    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;

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

    void UpdateJSON()
    {
        data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(Resources.Load<TextAsset>($"JSON/{JsonPath}").text);
        StringNumber = 0;
    }

    void OnStringChange()
    {
        try
        {
            if (StringNumber == data.Count - 1)
            {
                if (data[StringNumber].ContainsKey("choice"))
                {
                    mainPanel.SetActive(false);
                    choicePanel.SetActive(true);
                    choice1Text.text = data[StringNumber]["choice1string"];
                    choice2Text.text = data[StringNumber]["choice2string"];
                }
                return;
            }
            nameText.text = data[StringNumber]["name"];
            dialogueText.text = data[StringNumber]["text"];
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

    public void Forward()
    {
        StringNumber++;
        OnStringChange();
    }

    public void Back()
    {
        StringNumber--;
        OnStringChange();
    }

    public void OnChoice(int choice)
    {
        switch (choice)
        {
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
