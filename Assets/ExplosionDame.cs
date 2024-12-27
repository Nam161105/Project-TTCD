using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDame : MonoBehaviour
{

    [SerializeField] protected float dame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IDameage isCanDmg = collision.gameObject.GetComponent<IDameage>();  
            if (isCanDmg != null)
            {
                isCanDmg.TakeDamage(dame);
            }
        }
    }
}
