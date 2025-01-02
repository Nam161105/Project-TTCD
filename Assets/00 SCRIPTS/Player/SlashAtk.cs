using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlashAtk : CheckRangeAtk
{

    [SerializeField] protected GameObject _slashPrefab;
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected Image _skill1;
    protected float countDownAtk;

    private void Start()
    {
        if(_skill1 != null)
        {
            _skill1.fillAmount = 1;
        }
    }
    private void Update()
    {
        this.SlashAttack();
        this.UpdateImageSkill();
    }

    protected void SlashAttack()
    {
        countDownAtk -= Time.deltaTime;
        if(countDownAtk > 0)
        {
            return;
        }
        GameObject enemy = FindNearestEnemy(this.transform.position);
        if (enemy != null)
        {
            GameObject slash = ObjectPooling.Instance.GetObject(_slashPrefab.gameObject);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.slashClip);
            slash.SetActive(true);
            slash.transform.position = enemy.transform.position;

            countDownAtk = _atkSpeed;
        }
    }

    protected void UpdateImageSkill()
    {
        if (_skill1 != null)
        {
            _skill1.fillAmount = 1 - (countDownAtk / _atkSpeed);
        }
    }
}
