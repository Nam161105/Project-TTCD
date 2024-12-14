using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAtk : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab; 
    [SerializeField] protected float _atkSpeed;
    [SerializeField] protected float _atkRange;
    [SerializeField] protected LayerMask _enemyLayer; 

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

        GameObject enemy = FindNearestEnemy();
        if(enemy != null)
        {
            GameObject bullet = Instantiate(_bulletPrefab, this.transform.position, Quaternion.identity);
            Vector2 dir = enemy.transform.position - this.transform.position;

            BulletMove bulletMove = bullet.GetComponent<BulletMove>();
            if (bulletMove != null)
            {
                bulletMove.SetDir(dir);
            }

            countDownAtk = _atkSpeed; 
        }
    }

    protected GameObject FindNearestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, _atkRange, _enemyLayer);

        GameObject enemy = null;
        float shortestDis = Mathf.Infinity;
        foreach(Collider2D hit in hits)
        {
            float distance = Vector2.Distance(this.transform.position, hit.transform.position);
            if(distance < shortestDis)
            {
                shortestDis = distance;
                enemy = hit.gameObject;
            }
        }
        return enemy;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _atkRange);
    }
}