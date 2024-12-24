using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOK : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected DataPlayer _dataPlayer;
    [SerializeField] protected GameObject loadMain;

    public void Main()
    {
        SceneManager.LoadScene(_name);
        _dataPlayer.currentHp = _dataPlayer.maxHp;
        Time.timeScale = 1;
    }
}
