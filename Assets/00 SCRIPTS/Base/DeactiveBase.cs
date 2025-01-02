using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base DeActive cua gameobject
public class DeactiveBase : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(DeactiveAfterTime());
    }

    protected virtual IEnumerator DeactiveAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
