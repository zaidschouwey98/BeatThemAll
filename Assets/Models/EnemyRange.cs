using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    Animator anim;
    public bool isAttacking;
    private bool isHitable;
    private void Start() {
        isAttacking = false;
        anim = transform.parent.GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player") && !isAttacking){
            isAttacking = true;
            isHitable = true;
            
            StartCoroutine("Attack",other);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("SA SOOOOORT");
        isHitable = false;
        isAttacking = false;
    }
    IEnumerator Attack(Collider2D other){
        while(isAttacking){
            Debug.Log("Sa sort");
            anim.SetTrigger("attack");
            yield return new WaitForSeconds(transform.parent.GetComponentInParent<Character>().attackspeed);
            if(isHitable)
            {
                if(other.GetComponent<Character>())
                    other.GetComponent<Character>().receiveDamages(transform.parent.GetComponentInParent<Character>().dmg);
            }
               
        }
    }
}

