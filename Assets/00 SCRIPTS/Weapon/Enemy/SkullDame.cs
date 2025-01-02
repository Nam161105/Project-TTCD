using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDame : DameBase
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._playerTag))
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
