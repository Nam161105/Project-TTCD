using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAtk : MonoBehaviour
{
    
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float atkSpeed;
    protected float countDownAtk;

    private void Update()
    {
        this.CheckTimeAtk();
    }

    protected void CheckTimeAtk()
    {
        countDownAtk -= Time.deltaTime;
        if (countDownAtk > 0)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            countDownAtk = atkSpeed;
        }
    }
}
