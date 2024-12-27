using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionActive : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(ExplosionDeactive());
    }

    protected IEnumerator ExplosionDeactive()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
