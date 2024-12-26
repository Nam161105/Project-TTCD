using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDame : MonoBehaviour
{

    [SerializeField] protected float dame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDameage isCanTakeDmg = collision.gameObject.GetComponent<IDameage>();  
            if (isCanTakeDmg != null)
            {
                isCanTakeDmg.TakeDamage(dame);
                this.gameObject.SetActive(false);
            }
        }
    }
}