using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SlashDame : MonoBehaviour
{
    [SerializeField] protected float dame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDameage isCanDmg = collision.GetComponent<IDameage>();
            if (isCanDmg != null)
            {
                isCanDmg.TakeDamage(dame);
            }
        }
    }

}
