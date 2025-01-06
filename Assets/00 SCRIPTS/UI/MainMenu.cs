using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] protected GameObject _boardTutorial;
    public void LoadMap()
    {
        SceneLoading.Instance.SceneLoad(1);
    }

    public void Tutorial()
    {
        _boardTutorial.SetActive(true);
    }

    public void Cancel()
    {
        _boardTutorial.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
