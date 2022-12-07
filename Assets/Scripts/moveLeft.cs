using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float speed = 15f;
   
    
    private PlayerController playerControllerScript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {

     if (playerControllerScript.gameOver == false) { 
        
            if (playerControllerScript.faster)
            {
            transform.Translate(Vector3.left * Time.deltaTime * speed * 2);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
    
    }

        
       

       
        
        
    }
}
