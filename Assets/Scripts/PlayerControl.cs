using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Run
   public float MaxSpeed = 1;
    public bool FaceR;
    Rigidbody2D Player;
    Animator PlayerAnime;
    //jump and Glide
    bool grounded = false;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public float JumpHeight;
    float GroundCheckRad = .2f ;
    public float GlideGravity;

    //Shoot
    public Transform ThrowingHand;
    public GameObject Kunai;
    public float ThrowRate=1f;
    public float NextThrowtime=.5f;

    void Start()
    {
        Player =GetComponent<Rigidbody2D>();
        PlayerAnime = GetComponent<Animator>();
        FaceR = true;

    }
    void Update()
    {
        if (grounded && (Input.GetAxis("Jump")>0)) {
            PlayerAnime.SetBool("Grounded",false);
            Player.velocity = new Vector2(0,JumpHeight);
            
        }
        if (grounded)
        {
            PlayerAnime.SetFloat("ToggleGlide", 0);
            Player.drag = 0;
            Player.gravityScale = 1f;

        }
        if (!grounded && Input.GetKeyDown("space"))
        {
            Player.gravityScale = GlideGravity;
            PlayerAnime.SetFloat("ToggleGlide", 1);
            Player.drag = 1.5f;
            
        }


        //Attacks
        PlayerAnime.SetFloat("ThrowPower",0);
        if (Input.GetMouseButtonDown(0))
        {
            Throw();     
        }
        
    }
    void FixedUpdate()
    {
        float MoveH = Input.GetAxis("Horizontal");
        Player.velocity = new Vector2(MoveH * MaxSpeed, Player.velocity.y);
        PlayerAnime.SetFloat("Speed", Mathf.Abs(MoveH));

        if (MoveH > 0 && !FaceR) {
            flip();
        }
        else if (MoveH < 0 && FaceR)
        {
            flip();
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRad,GroundLayer);
        PlayerAnime.SetBool("Grounded",grounded);
        PlayerAnime.SetFloat("VerticalSpeed", Player.velocity.y);
        
    }

    
    void flip()
    {
        Vector3 Scale =Player.transform.localScale;
        FaceR = !FaceR;
        Scale.x = Scale.x * -1;
        Player.transform.localScale = Scale;
    }

    void Throw()
    {
        if (Time.time > NextThrowtime)
        {
            NextThrowtime = Time.time + ThrowRate;
            if (FaceR)
            { 
              Instantiate(Kunai, ThrowingHand.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                PlayerAnime.SetFloat("ThrowPower", Mathf.Abs(Input.GetAxis("Fire1")));

            }
            else
            {
                Instantiate(Kunai, ThrowingHand.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                PlayerAnime.SetFloat("ThrowPower", Mathf.Abs(Input.GetAxis("Fire1")));
            }

        }
    }
}
