using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefebs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float spawnInterval = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObastacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnRandomObastacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefebs.Length);
            Instantiate(obstaclePrefebs[obstacleIndex], spawnPos, obstaclePrefebs[obstacleIndex].transform.rotation);
        }
      
    }

}
