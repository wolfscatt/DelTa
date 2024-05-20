using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject mutedSoundButton;
    private bool isMuted = false;
    void Start()
    {
        if (settingsMenu != null)
        {
            settingsMenu.SetActive(false); 
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
        playCanvas.SetActive(false);
        Debug.Log("works");
    }
    public void SoundButton()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
        soundButton.SetActive(!isMuted);
        mutedSoundButton.SetActive(isMuted);
    }
}
