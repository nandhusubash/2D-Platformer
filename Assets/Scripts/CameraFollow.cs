using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerLoc;
    public float Smoothening;
    Vector3 Offset;
    float Ylimit;

    void Start()
    {
        Offset = transform.position - PlayerLoc.position;
        Ylimit = transform.position.y - 1;
    }
    void FixedUpdate()
    {
        Vector3 CurrentPlayerLoc = PlayerLoc.position + Offset;
        transform.position = Vector3.Lerp(transform.position, CurrentPlayerLoc, Smoothening*Time.deltaTime);
        if (transform.position.y < Ylimit)
        {
            transform.position = new Vector3(transform.position.x, Ylimit, transform.position.y);
        }


        
    }
}
