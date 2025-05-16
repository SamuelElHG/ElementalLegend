using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void DamageFunction(float damage)
    {
        currentHealth -= damage;
        Debug.Log("o no recibo daño y es " + damage);
        if (currentHealth < 0)
        {
            Debug.Log("O no me morí");
            Destroy(gameObject);
        }
    }
}
