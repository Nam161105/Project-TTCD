using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAtk : CheckRangeAtk
{
    [SerializeField] protected GameObject _bulletPrefab; 
    [SerializeField] protected float _atkSpeed;
    

    protected float countDownAtk;


    private void Update()
    {
        CheckTimeAtk();
    }

    protected void CheckTimeAtk()
    {
        countDownAtk -= Time.deltaTime;
        if(countDownAtk > 0)
            return;

        GameObject enemy = FindNearestEnemy(this.transform.position);
        if(enemy != null)
        {
            GameObject bullet = ObjectPooling.Instance.GetObject(_bulletPrefab.gameObject);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.fireClip);
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

    

    
}