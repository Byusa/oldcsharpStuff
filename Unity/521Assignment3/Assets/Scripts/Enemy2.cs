using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public int maxValue = 15;
    public int minValue = -14;
    public int speedAmt = 10; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position.z <= minValue)
        {
            speedAmt = 10;
        }

        if(transform.position.z >= maxValue)
        {
            speedAmt = -10;
        }*/

        transform.Translate(0, 0, -speedAmt * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject box = new GameObject();


        //Move it if it's collides with UpDoor1
        if (collision.gameObject.name == "UpDoor1")
        {
            //Debug.Log(transform.position);
            speedAmt = 10;
            transform.Translate(0, 0, speedAmt * Time.deltaTime);
        }

        //Move it if it's collides with UpDoor2
        if (collision.gameObject.name == "DownDoor1")
        {
            //Debug.Log(transform.position);
            speedAmt = -10;
            transform.Translate(0, 0, speedAmt * Time.deltaTime);
        }

        int randomNumber = (int)Random.Range(1, 4);
        //Debug.Log(randomNumber);
        //randomNumber =1;

        var TheX=0.0f;
        var TheY=0.0f; 
        var TheZ=0.0f;

        if ((randomNumber == 1) && (collision.gameObject.name == "LeftSmallObstacles"))
        {
             TheX = transform.position.x;
             TheY = transform.position.y;
             TheZ = transform.position.z;

            transform.position = new Vector3(-5.0f, 0f, 15f); //(-5.8,0.9,15.2)
        }
        if ((randomNumber == 2) && (collision.gameObject.name == "LeftSmallObstacles"))
        {
            TheX = transform.position.x;
            TheY = transform.position.y;
            TheZ = transform.position.z;

            transform.position = new Vector3(-5.0f, 0f, -14f); //(-5.0, 0.8, -14.0)
        }
        if (randomNumber == 3)
        {
            box = GameObject.FindGameObjectWithTag("LeftSmallObstacles");
            box.GetComponent<BoxCollider>().enabled = false;
        }
        box.GetComponent<BoxCollider>().enabled = true;
    }
}
