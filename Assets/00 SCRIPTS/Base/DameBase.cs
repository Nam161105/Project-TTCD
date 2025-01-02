using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base cua gay dame cho enemy
public class DameBase : MonoBehaviour
{
    [SerializeField] protected float dame;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT._enemyTag))
        {
            IDameage isCanDmg = collision.GetComponent<IDameage>();
            if (isCanDmg != null)
            {
                isCanDmg.TakeDamage(dame);
            }
        }
    }
}
