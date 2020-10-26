using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float dmg;
    protected int hp;
    protected int attackspeed;

    public abstract void Move();
    public void Die(){
        Destroy(this.gameObject);
    }
    public void getDamages(int damages){
        dmg -= damages;
        if(hp<=0)
            Die();
    }
    private void Start() {
        
    }
}   
