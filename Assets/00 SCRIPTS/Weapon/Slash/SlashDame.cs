using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDame : MonoBehaviour
{
    [SerializeField] protected float atkRange;
    [SerializeField] protected LayerMask _enemy;
    [SerializeField] protected float dame;

    private void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, atkRange, _enemy);
        foreach(Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                IDameage isCanDmg = hit.GetComponent<IDameage>();
                if (isCanDmg != null)
                {
                    isCanDmg.TakeDamage(dame);
                }
            }
        }
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
}
