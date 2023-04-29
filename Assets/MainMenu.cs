using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseSettings(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
