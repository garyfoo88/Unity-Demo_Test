using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    //public GameObject obstaclePrefab --> the obstacle prefab to be cloned/spawn(to be added in unity editor)
    private Vector3 spawnPos = new Vector3(40, 0, 0);
    //private Vector3 spawnPos = new Vector(40, 0, 0) --> set spawn position;
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        //InvokeRepeating("SpawnObstacle", startDelay, repeatDelay) --> repeat a certain function with startdelay and repeating delay;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        //if (playerControllerScript.gameOver == false)
        if (playerControllerScript.gameOver == false)
            {
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
                //Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation) --> clone obstacle prefab with initial spawn position and rotation.
            }
        
    }
}
