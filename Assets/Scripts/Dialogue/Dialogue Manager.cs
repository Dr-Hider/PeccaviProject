using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public int StringNumber { get; set; }
    List<Dictionary<string, string>> data;
    public TextAsset json;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public SpriteRenderer background;

    void Awake()
    {
        data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json.text);
    }
    void Start()
    {
        OnChangeString();
    }

    public void OnChangeString()
    {
        try
        {
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
        }

    }
    public void Forward()
    {
        StringNumber++;
        OnChangeString();
    }
    public void Back()
    {
        StringNumber--;
        OnChangeString();
    }
}
