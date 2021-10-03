using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiHit : MonoBehaviour
{
    ProjectileController PC;

    public float KunaiDamage;
    public GameObject BloodSplatter;
    public GameObject DirtSplatter;

    public Transform SplashLoc;


    void Awake()
    {
        PC = GetComponentInParent<ProjectileController>();
    }


    void Update(){}
   
   void OnTriggerEnter2D(Collider2D other)
   {
        SplashLoc.position = new Vector3(transform.position.x + 0.8f, transform.position.y + 0.5f, -6);
         if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") )

           {
            
                PC.RemoveForce();
                if (other.tag == "Bleedy")
                {
                     Instantiate(BloodSplatter, SplashLoc.position, transform.rotation);
                    EnemyDamage HurtEnemy = other.gameObject.GetComponent<EnemyDamage>();
                     HurtEnemy.AddDamage(KunaiDamage);
                }
                if (other.tag == "NonBleedy")
                {
                    Instantiate(DirtSplatter, SplashLoc.position, transform.rotation);
                     EnemyDamage HurtEnemy = other.gameObject.GetComponent<EnemyDamage>();
                HurtEnemy.AddDamage(KunaiDamage);
                }
                Destroy(gameObject);
            }
        if (other.gameObject.layer != LayerMask.NameToLayer("Shootable"))
        {
            Instantiate(DirtSplatter, SplashLoc.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        SplashLoc.position = new Vector3(transform.position.x + 0.8f, transform.position.y + 0.5f, -6);
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            PC.RemoveForce();
            if (other.tag == "Bleedy")
            {
                Instantiate(BloodSplatter, SplashLoc.position, transform.rotation);
                EnemyDamage HurtEnemy = other.gameObject.GetComponent<EnemyDamage>();
                HurtEnemy.AddDamage(KunaiDamage);
            }
            if (other.tag == "NonBleedy")
            {
                Instantiate(DirtSplatter, SplashLoc.position, transform.rotation);
                EnemyDamage HurtEnemy = other.gameObject.GetComponent<EnemyDamage>();
                HurtEnemy.AddDamage(KunaiDamage);
            }
            Destroy(gameObject);
        }
        if(other.gameObject.layer!=LayerMask.NameToLayer("Shootable"))
        {
            Instantiate(DirtSplatter, SplashLoc.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}
