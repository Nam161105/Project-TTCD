using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActive : DeactiveBase
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._enemyTag))
        {
            this.gameObject.SetActive(false);
        }
    }

}
