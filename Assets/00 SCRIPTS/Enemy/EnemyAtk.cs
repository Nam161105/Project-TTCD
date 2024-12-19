using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    [SerializeField] protected int dame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            IDameage iscanDmg = collision.gameObject.GetComponent<IDameage>();
            if (iscanDmg != null)
            {
                iscanDmg.TakeDamage(dame);
            }
        }
    }
}
