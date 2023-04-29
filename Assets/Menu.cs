using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(1);
    }
}
