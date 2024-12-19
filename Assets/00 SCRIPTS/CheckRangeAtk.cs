using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRangeAtk : MonoBehaviour
{
    [SerializeField] protected float _atkRange;
    [SerializeField] protected LayerMask _enemyLayer;
    protected GameObject FindNearestEnemy(Vector2 position)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, _atkRange, _enemyLayer);

        GameObject enemy = null;
        float shortestDis = Mathf.Infinity;
        foreach (Collider2D hit in hits)
        {
            float distance = Vector2.Distance(this.transform.position, hit.transform.position);
            if (distance < shortestDis)
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
