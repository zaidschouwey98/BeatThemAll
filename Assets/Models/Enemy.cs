using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject healthBar,healthBackground,health;
    protected float hearthPoints;
    protected float maxHealth;
    private float healthToScaleBar;
    public int damages;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveDamages(float damages){
        Debug.Log(hearthPoints);
        this.hearthPoints -= damages;
        if(hearthPoints<=0){
            Destroy(transform.gameObject);
        }
        healthBar.transform.localScale = new Vector3(hearthPoints/maxHealth,1,0);
    }
}
