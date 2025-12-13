using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public TextMeshProUGUI endingName;
    public TextMeshProUGUI endingDescription;

    void Awake()
    {
        endingName.text = EndingParams.EndingName;
        endingDescription.text = EndingParams.EndingDescription;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
