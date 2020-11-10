using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject healthBar,healthBackground,health;
    public float dmg;
    public float hp,maxHp;
    public float attackspeed;
   
    public void receiveDamages(float damages){
        Debug.Log(hp);
        this.hp -= damages;
        if(hp<=0){
            Destroy(transform.gameObject);
        }
        if(!gameObject.tag.Equals("Player"))
            healthBar.transform.localScale = new Vector3(hp/maxHp,1,0);


    }
    private void Start() {
        
    }
}   
