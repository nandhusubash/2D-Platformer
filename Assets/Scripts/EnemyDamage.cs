using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float MaxHealth;
    float CurrentHealth;
    void Start()
    {
        CurrentHealth = MaxHealth; 
    }
    void Update(){}
    public void AddDamage(float WeaponDamge)
    {
        CurrentHealth -= WeaponDamge;
        if (CurrentHealth <= 0)
        {
            killEnemy();
            Debug.Log("Killed");
        }
    }
    public void killEnemy()
    {
        Destroy(gameObject);
    }
}
