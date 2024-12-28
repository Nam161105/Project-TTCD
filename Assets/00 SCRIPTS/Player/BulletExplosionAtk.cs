using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosionAtk : CheckRangeAtk
{
    [SerializeField] protected GameObject _swordBullet;
    [SerializeField] protected float _atkSpeed;
    protected float countDownAtk;


    private void Update()
    {
        this.CheckTimeAtk();
    }

    protected void CheckTimeAtk()
    {
        countDownAtk -= Time.deltaTime;
        if(countDownAtk > 0)
        {
            return;
        }
        GameObject enemy = FindNearestEnemy(this.transform.position);
        if(enemy != null)
        {
            GameObject g = ObjectPooling.Instance.GetObject(_swordBullet.gameObject);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.fireClip2);
            g.SetActive(true);
            g.transform.position = this.transform.position;
            Vector2 dis = enemy.transform.position - this.transform.position;
            float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg - 90;
            g.transform.rotation = Quaternion.Euler(0, 0, angle);
            SwordMove _swordMove = g.GetComponent<SwordMove>();
            if (_swordMove != null)
            {
                _swordMove.SetDir(dis);
            }
            countDownAtk = _atkSpeed;
        }
        
    }

}
