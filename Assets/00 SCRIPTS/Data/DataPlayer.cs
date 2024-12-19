using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/Player")]
public class DataPlayer : ScriptableObject
{
    public float maxHp;
    public float currentHp;
}
