using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public int exp;
    [SerializeField] private int expThreshold;

    [SerializeField] public float health, AttackDamage, Defense ;

}
