using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private int randomize;
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playercontrollerscript;


    // Start is called before the first frame update
    void Start()
    {
        playercontrollerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Spawnit", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawnit()
    {
        randomize = Random.Range(0, obstacles.Length);
        spawnPos.x = Random.Range(25, 35);
        if (playercontrollerscript.gameOver == false)
            Instantiate(obstacles[randomize], spawnPos, obstacles[randomize].transform.rotation);
    }


}
