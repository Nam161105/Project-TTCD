using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDame : DameBase
{

    [SerializeField] protected GameObject _explosionPrefab;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._enemyTag))
        {
            GameObject explo = ObjectPooling.Instance.GetObject(_explosionPrefab.gameObject);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.explosion);
            explo.SetActive(true);
            explo.transform.position = this.transform.position;
            explo.transform.rotation = Quaternion.identity;
            this.gameObject.SetActive(false);
        }
    }
}
