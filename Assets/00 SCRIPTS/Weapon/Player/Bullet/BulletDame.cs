using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDame : MonoBehaviour
{
    [SerializeField] protected int dame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IDameage isCanTakeDmg = collision.gameObject.GetComponent<IDameage>();
            if(isCanTakeDmg != null)
            {
                isCanTakeDmg.TakeDamage(dame);
            }
        }
    }
}
