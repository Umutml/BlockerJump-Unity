using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outbound : MonoBehaviour
{

    private float leftbound = -3f;
    private GameManager gameManagerscript;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       


        if (transform.position.x <= leftbound )
        {

            gameManagerscript.scorer += 500;
            gameManagerscript.ScoreTeller();
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
       

     
    }




}

