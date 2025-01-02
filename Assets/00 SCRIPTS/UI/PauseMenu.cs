using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] protected GameObject pauseMenu;

    public void MenuPause() //Nut pause
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() //Tiep tuc
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart() //Reset lai man choi
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu() //Ve lai MainMenu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
