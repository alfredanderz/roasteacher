using UnityEngine;
using UnityEngine.SceneManagement; // 👈 ESTA LÍNEA ES CLAVE

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenMainPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1"); // 👈 ahora sí Unity lo reconocerá
    }
}
