using Newtonsoft.Json;

// Class to transfer save data between scenes
public class SaveData
{
    // Static properities for use
    [JsonIgnore]
    public static string Scene { get; set; }

    [JsonIgnore]
    public static string JsonPath { get; set; }
    
    [JsonIgnore]
    public static int StringNumber { get; set; }

    // Non static properties for a serialization
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

    // Default (new game) state
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
