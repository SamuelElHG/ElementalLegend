using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaScript : MonoBehaviour
{
    [SerializeField] private PlayerStats plaStats;

    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 /*   void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            EnemyScript targetEnemy = collision.gameObject.GetComponent<EnemyScript>();

            targetEnemy.DamageFunction(damage);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            EnemyScript enemyScript = other.gameObject.GetComponent<EnemyScript>(); 
            enemyScript.DamageFunction(plaStats.AttackDamage);

        }
    }
}
