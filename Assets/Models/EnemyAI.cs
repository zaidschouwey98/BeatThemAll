using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private bool flipX;
    public Transform target;
    public float speed = 80f;
    public float nextWaypointDistance =3f;
    Path path;
    int CurrentWaypoint = 0;
    bool reachEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        flipX = false;
        seeker=GetComponent<Seeker>();
        rb=GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath",0f,1f);
        
    }
    void UpdatePath(){
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position,OnPathComplete);
    }
    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            CurrentWaypoint = 0;
        }
    }
    void Move(){
        
    }
    private void Update() {
        if(flipX){
            transform.localScale = new Vector3(-1,1,1);
        }
        if(!flipX)
            transform.localScale = new Vector3(1,1,1);
    }   
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path==null){
            return;
        }
        if(CurrentWaypoint>=path.vectorPath.Count){
            reachEndOfPath = true;
            return;
        } else{
            reachEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[CurrentWaypoint]-rb.position).normalized;
        Vector2 force = direction*speed*Time.deltaTime;
        Vector2 velocity = rb.velocity;
        velocity.x = force.x;
        rb.velocity = velocity;
        if(rb.velocity.x <0){
            flipX = true;
        } else if (rb.velocity.x>0){
            flipX = false;
        }
        Debug.Log(rb.velocity.x);
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position,path.vectorPath[CurrentWaypoint]);
        if(distance<nextWaypointDistance){
            CurrentWaypoint++;
        }
    
    }
}
