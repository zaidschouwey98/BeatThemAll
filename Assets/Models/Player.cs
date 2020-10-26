using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private CircleCollider2D range;
    private bool isGrounded;
    private bool canAttack;
    private bool flipx;
    private float horizontalInput;
    private float moveSpeed;
    private SpriteRenderer sr;
    Animator knight_animator;
    Rigidbody2D rb;
    public float thrust;
    override public void Move(){
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }
    private void Start() {
        hp = 100;
        dmg = 20;
        thrust = 10f;
        canAttack=true;
        moveSpeed = 10f;
        isGrounded = false;
        knight_animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        
    }
    private void Update(){
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput == -1){
           flipx = true;
            
        }else if (horizontalInput == 1){
            flipx = false;
        }
        if(flipx){
            sr.flipX = true;
        } else { sr.flipX = false; }
        
        knight_animator.SetFloat("Speed",Mathf.Abs(horizontalInput));
        if(!isGrounded)
            knight_animator.SetBool("isJumping",true);
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
            rb.AddForce(new Vector2(0, 1) * thrust,ForceMode2D.Impulse);
            knight_animator.SetBool("isJumping",true);
        }
        if(Input.GetKeyDown(KeyCode.Space)&&canAttack){
            if(isGrounded){
                canAttack=false;
                knight_animator.SetTrigger("Attack");
                
            } else if(!isGrounded){
                knight_animator.SetTrigger("jumpAttack");
            }
            StartCoroutine("Attack");
        } 
        Move();
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.6f);
        canAttack = true;
    }
    void FixedUpdate() {
        
       
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = true;
            knight_animator.SetBool("isJumping",false);
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = false;
            knight_animator.SetBool("isJumping",true);

        }
    }
   
}
