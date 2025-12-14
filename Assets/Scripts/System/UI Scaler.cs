using UnityEngine;
using UnityEngine.UI;

// Script for correct displaying UI
public class UIScaler : MonoBehaviour
{
    static int width = Screen.width;
    static int height = Screen.height;
    CanvasScaler canvasScaler;

    void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        if ((float)width / (float)height < 16f / 9f)
            canvasScaler.matchWidthOrHeight = 0f; // Match by width
    }
}
