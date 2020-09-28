using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private CircleCollider2D range;
    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<CircleCollider2D>();
        range.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && range.enabled ==false){
            
            StartCoroutine("Attack");
        }
    }
    IEnumerator Attack(){
        
        yield return new WaitForSeconds(0.6f);
        range.enabled = true;
        range.enabled = false;

    }
    private void OnCollisionEnter2D(Collision2D other) {
        
    }
}
