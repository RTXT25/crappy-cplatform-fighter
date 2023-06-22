using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour{    
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float fallMult = 2.5f;
    static public int maxJumps = 2;
    Rigidbody2D rb;
    bool inFastFall;
    static public bool isGround;
    static public int jumpsLeft;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start(){
        jumpsLeft = maxJumps;
    }
    void Update(){
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump")){
            if (jumpsLeft > 0){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsLeft--;
            }
        }
        if (Input.GetAxisRaw("Vertical") < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;
            if(isGround){
                jumpsLeft = maxJumps;
                //Input.GetAxis("Vertical") = 1;
            }
        }
    }
}
