using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActive : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(DeactiveAfterTime());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }

    protected IEnumerator DeactiveAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
