using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    public LayerMask enemyLayer;
    public Transform attackPoint;
    public float attackRange = 0.9f;
    private CircleCollider2D range;
    private bool isGrounded;
    private bool canAttack;
    private bool flipx;
    private float horizontalInput;
    private float moveSpeed;
    private SpriteRenderer sr;
    Animator knight_animator;
    Rigidbody2D rb;
    public float thrust,strikeThrust;
    void Move(){
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }
    private void Start() {
        hp = 100;
        dmg = 20;
        thrust = 10f;
        strikeThrust = 5f;
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
            transform.localScale = new Vector3(-1,1,1);
        } else { 
            transform.localScale = new Vector3(1,1,1);
         }
        
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
        if(Input.GetKeyDown(KeyCode.LeftShift)&&canAttack){
            canAttack = false;
            knight_animator.SetTrigger("strikeAttack");
            if(flipx){
            rb.AddForce(new Vector2(-1, 0) * strikeThrust,ForceMode2D.Impulse);
            }else {
                rb.AddForce(new Vector2(1, 0) * strikeThrust,ForceMode2D.Impulse);
            }
            StartCoroutine("Attack");
            
            
        } 
        Move();
    }
    IEnumerator Attack()
    {
        
        yield return new WaitForSeconds(0.45f);
        Collider2D[] Targets = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);
        foreach(Collider2D target in Targets)
        {
            if(target.GetComponent<Character>())
            {
                Debug.Log(target);
                Debug.Log("j'attaque la");
                target.GetComponent<Character>().receiveDamages(dmg);
            }
        }
            
            
        canAttack = true;
    }
    void OnDrawGizmosSelected() {
        if(attackPoint==null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
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
