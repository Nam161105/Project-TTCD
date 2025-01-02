using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ScripsTableObject cua Player
[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/Player")]
public class DataPlayer : ScriptableObject
{
    public float maxHp;
    public float currentHp;
}
