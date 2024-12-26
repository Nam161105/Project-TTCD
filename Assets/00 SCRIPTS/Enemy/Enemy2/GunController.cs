using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] protected GameObject gun;
    [SerializeField] protected float time;
    protected float countDownAtk;


    public void Damer()
    {
        countDownAtk -= Time.deltaTime;
        if(countDownAtk > 0)
        {
            return;
        }
        Instantiate(gun, this.transform.position, Quaternion.identity);
        countDownAtk = time;
    }
}
