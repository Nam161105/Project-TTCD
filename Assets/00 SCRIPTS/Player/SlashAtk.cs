using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAtk : CheckRangeAtk
{

    [SerializeField] protected GameObject _slashPrefab;
    [SerializeField] protected float _atkSpeed;
    protected float countDownAtk;
    private void Update()
    {
        this.SlashAttack();
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
            slash.SetActive(true);
            slash.transform.position = enemy.transform.position;

            countDownAtk = _atkSpeed;
        }
    }
}
