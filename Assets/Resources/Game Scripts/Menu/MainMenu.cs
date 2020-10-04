using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene(string.Format("CharacterCustomization"));
    }
    public void OpenGalley()
    {
        SceneManager.LoadScene(string.Format("Gallery"));
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(string.Format("Settings"));
    }

    public void OpenLoad()
    {
        SceneManager.LoadScene(string.Format("SaveLoad"));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
