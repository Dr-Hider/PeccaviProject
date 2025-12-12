using Newtonsoft.Json;
using UnityEngine;

public class SaveData
{
    [JsonIgnore]
    public static string Scene { get; set; }

    [JsonIgnore]
    public static string JsonPath { get; set; }
    
    [JsonIgnore]
    public static int StringNumber { get; set; }

    [JsonProperty("Scene")]
    public string NonStaticScene
    {
        get { return Scene; }
        set { Scene = value; }
    }
    
    [JsonProperty("JsonPath")]
    public string NonStaticJsonPath
    {
        get { return  JsonPath; }
        set {  JsonPath = value; }
    }

    [JsonProperty("StringNumber")]
    public int NonStaticStringNumber
    {
        get { return StringNumber; }
        set {  StringNumber = value; }
    }

    public SaveData()
    {
        Scene = "Chapter 1 Introduction";
        JsonPath = "Chapter 1/Introduction/Introduction";
        StringNumber = 0;
    }
    public SaveData(string scene, string jsonPath, int stringNumber)
    {
        Scene = scene;
        JsonPath = jsonPath;
        StringNumber = stringNumber;
    }
}
