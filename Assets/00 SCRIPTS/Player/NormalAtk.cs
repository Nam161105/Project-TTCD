using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalAtk : CheckRangeAtk
{
    [SerializeField] protected GameObject _bulletPrefab; 
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected Image _skill2;

    protected float countDownAtk;

    private void Start()
    {
        if(_skill2 != null)
        {
            _skill2.fillAmount = 1;
        }
    }
    private void Update()
    {
        this.CheckTimeAtk();
        this.UpdateImageSkill2();
    }

    protected void CheckTimeAtk()
    {
        countDownAtk -= Time.deltaTime;
        if(countDownAtk > 0)
            return;

        GameObject enemy = FindNearestEnemy(this.transform.position);
        if(enemy != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.fireClip);

            GameObject bullet = ObjectPooling.Instance.GetObject(_bulletPrefab.gameObject);
            bullet.transform.position = this.transform.position;
            bullet.SetActive(true);

            Vector2 dir = enemy.transform.position - this.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            BulletMove bulletMove = bullet.GetComponent<BulletMove>();
            if (bulletMove != null)
            {
                bulletMove.SetDir(dir);
            }

            countDownAtk = _atkSpeed; 
        }
    }

    protected void UpdateImageSkill2()
    {
        if (_skill2 != null)
        {
            _skill2.fillAmount = 1 - (countDownAtk / _atkSpeed);
        }
    }

    
}