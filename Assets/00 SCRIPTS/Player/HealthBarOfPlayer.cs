using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBarOfPlayer : MonoBehaviour, IDameage
{
    [SerializeField] protected DataPlayer _dataPlayer;
    [SerializeField] protected Image _fill;

    [SerializeField] protected string _name;
    private void Start()
    {
        this.UpdateHealthBar();
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
        Debug.Log("Player is die");
        SceneManager.LoadScene(_name);
        _dataPlayer.currentHp = _dataPlayer.maxHp;
    }

    protected void UpdateHealthBar()
    {
        _fill.fillAmount = _dataPlayer.currentHp / _dataPlayer.maxHp;
    }
}
