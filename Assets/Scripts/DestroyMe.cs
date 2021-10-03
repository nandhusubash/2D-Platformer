using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyMe : MonoBehaviour
{
    public float LifeTime;
    void Awake()
    {
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
