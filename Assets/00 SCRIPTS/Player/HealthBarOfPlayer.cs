using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarOfPlayer : MonoBehaviour, IDameage
{
    [SerializeField] protected DataPlayer _dataPlayer;
    [SerializeField] protected Image _fill;
    [SerializeField] protected GameObject _boardTimeOfPlayer;
    [SerializeField] protected Text _timeText;
    [SerializeField] protected Transform _health;
    private void Start()
    {
        this.UpdateHealthBar();
    }

    private void Update()
    {
        this.HealthNoRotate();  
    }

    protected void HealthNoRotate() //Giu nguyen thanh mau khong bi doi scale theo thang cha(Player)
    {
        _health.localScale = new Vector3(0.005f / transform.localScale.x, 0.005f / transform.localScale.y, 1);
    }

    public void TakeDamage(float dame)
    {
        _dataPlayer.currentHp -= dame;
        this.UpdateHealthBar();
        if (_dataPlayer.currentHp < 0)
        {
            Die();
        }
    }
    
    protected void Die()
    {
        TimerManager.Instance.ReturnGame();
        float savedTime = PlayerPrefs.GetFloat("SavedTime", 0);

        int min = Mathf.FloorToInt(savedTime / 60);
        int sec = Mathf.FloorToInt(savedTime % 60);

        _timeText.text = string.Format("{0:00} : {1:00}", min, sec);
           
        _boardTimeOfPlayer.SetActive(true);
        Time.timeScale = 0; //Dung thoi gian cua game lai
        
  
    }

    protected void UpdateHealthBar() //Update imgae theo currentHp hien tai
    {
        _fill.fillAmount = _dataPlayer.currentHp / _dataPlayer.maxHp;
    }

    
}
