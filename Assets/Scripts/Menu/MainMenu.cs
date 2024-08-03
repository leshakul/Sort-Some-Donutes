using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {        
        SceneManager.LoadScene(1);                      
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteKey("_isPlay");
        Application.Quit();
    }
}
