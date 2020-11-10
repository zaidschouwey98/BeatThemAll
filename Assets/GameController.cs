using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Slider slider;
    public GameObject init_Player,init_Heavy,init_Skeleton,init_MainCam;
    private GameObject Player,Heavy,Skeleton,MainCam;
    private int rndSpawnLocation;
    private List<Vector3> spawnLocations;
   
    private void Awake() {
        spawnLocations = new List<Vector3>(){
            new Vector3(-24.07879f,2.223444f,0),
            new Vector3(-44.05f,0.32f,0),
            new Vector3(14.6f,1.35f,0)
        };
            
        
        Player = Instantiate(init_Player) as GameObject;
        MainCam = Instantiate(init_MainCam) as GameObject;
        
        // Skeleton = Instantiate(init_Skeleton,spawnLocations[randomSpawnLocation()],gameObject.transform.rotation) as GameObject;
        // Skeleton.GetComponent<EnemyAI>().target = Player.transform;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        MainCam.GetComponent<Camera>().player = Player;
        
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Player.GetComponent<Character>().hp; 
    }
    IEnumerator SpawnEnemy(){
        while(true){
            
            Skeleton = Instantiate(init_Skeleton,spawnLocations[randomSpawnLocation()],gameObject.transform.rotation) as GameObject;
            Skeleton.GetComponent<EnemyAI>().target = Player.transform;
            Debug.Log("SA SPAWN");
            yield return new WaitForSeconds(10);
        }
    }
    public int randomSpawnLocation(){
        
        rndSpawnLocation = Random.Range(0,3);
        return rndSpawnLocation;
    }
}
