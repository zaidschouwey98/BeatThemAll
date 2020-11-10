using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform camTransform;
    public GameObject player;
    private Transform newPos;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = player.GetComponent<Transform>();
        if(newPos.position.x <= -32.8222f || newPos.position.x >= 4.723098f){

        }else{
            camTransform.position = new Vector3(newPos.position.x,1,-10);
        }
            
    }
}
