using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Rigidbody2D kunai;
    public float KunaiSpeed;

    //public float LifeTime;
    void Awake()
    {
        kunai =GetComponent<Rigidbody2D>();
        if (transform.localRotation.z >0)
        {
            kunai.AddForce(new Vector2(-1, 0)*KunaiSpeed, ForceMode2D.Impulse);
            
        }
        else
        {
            kunai.AddForce(new Vector2(1, 0)*KunaiSpeed, ForceMode2D.Impulse);
        }


        //Destroy(gameObject,LifeTime);
    }

   
   public void RemoveForce()
    {
        kunai.AddForce(new Vector2(0, 0));
        Destroy(gameObject);
    }
    void Update()
    {
        
    }


}
