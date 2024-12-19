using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashActive : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;


    private void OnEnable()
    {
        StartCoroutine(DeactiveAfterTime());
    }
    protected IEnumerator DeactiveAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
