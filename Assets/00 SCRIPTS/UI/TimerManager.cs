using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    protected static TimerManager instance;
    public static TimerManager Instance => instance;

    [SerializeField] protected Text timer;
    protected float time;
    protected bool isPaused = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        this.RunTimer();
    }

    protected void RunTimer()
    {
        if(!isPaused)
        {
            time += Time.deltaTime;
            int min = Mathf.FloorToInt(time / 60);
            int sec = Mathf.FloorToInt(time % 60);

            timer.text = string.Format("{0:00} : {1:00}", min, sec);
        }
    }

    public void ReturnGame()
    {
        isPaused = false; //Dung thoi gian game lai
        PlayerPrefs.SetFloat("SavedTime", time); //Luu lai thoi gian game
    }
}
