using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletExplosionAtk : CheckRangeAtk
{
    [SerializeField] protected GameObject _swordBullet;
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected Image _skill3;
    protected float countDownAtk;

    private void Start()
    {
        if(_skill3 != null)
        {
            _skill3.fillAmount = 1;
        }
    }
    private void Update()
    {
        this.CheckTimeAtk();
        this.UpdateImageSkill3();
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
            AudioManager.Instance.PlaySFX(AudioManager.Instance.fireClip2); //Am thanh

            GameObject g = ObjectPooling.Instance.GetObject(_swordBullet.gameObject); //Tao ra gameobject
            g.SetActive(true);
            g.transform.position = this.transform.position;

            Vector2 dis = enemy.transform.position - this.transform.position; //Tinh goc xoay
            float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg - 90;
            g.transform.rotation = Quaternion.Euler(0, 0, angle);

            SwordMove _swordMove = g.GetComponent<SwordMove>();
            if (_swordMove != null)
            {
                _swordMove.SetDir(dis); //Set huong cua sword
            }
            countDownAtk = _atkSpeed;
        }
        
    }

    protected void UpdateImageSkill3()
    {
        if (_skill3 != null)
        {
            _skill3.fillAmount = 1 - (countDownAtk / _atkSpeed);
        }
    }
}
