using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDmg : MonoBehaviour, IDameage
{
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;


    private void OnEnable()
    {
        currentHp = maxHp;
    }
    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(float dame)
    {
        currentHp -= dame;
        if (currentHp <= 0)
        {
            Debug.Log("Enemy die");
            this.gameObject.SetActive(false);
        }
    }
}
