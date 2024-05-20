using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject backToGameButton;
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        playCanvas.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
