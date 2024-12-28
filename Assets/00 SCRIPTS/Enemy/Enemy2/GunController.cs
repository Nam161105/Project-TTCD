using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] protected GameObject gun;
    [SerializeField] protected float time;
    protected float countDownAtk;


    public void Shoot()
    {
        countDownAtk -= Time.deltaTime;
        if(countDownAtk > 0)
        {
            return;
        }
        GameObject skullBullet = ObjectPooling.Instance.GetObject(gun.gameObject);
        skullBullet.SetActive(true);
        skullBullet.transform.position = this.transform.position;
        skullBullet.transform.rotation = Quaternion.identity;
        countDownAtk = time;
    }
}
