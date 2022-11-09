using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefeb;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObastacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnObastacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefeb, spawnPos, obstaclePrefeb.transform.rotation);
        }
        
    }

}
