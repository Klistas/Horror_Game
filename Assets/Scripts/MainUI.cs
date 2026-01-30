using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
