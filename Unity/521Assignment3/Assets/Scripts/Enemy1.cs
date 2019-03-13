using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
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

        transform.Translate(0, 0, -speedAmt * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject box = new GameObject();
        if (collision.gameObject.name == "UpDoor2")
        {
            speedAmt = 10;
            transform.Translate(0, 0, speedAmt * Time.deltaTime);
        }
        if (collision.gameObject.name == "DownDoor2")
        {
            Debug.Log(transform.position);
            speedAmt = -10;
            transform.Translate(0, 0, speedAmt * Time.deltaTime);
        }

        int randomNumber = (int)Random.Range(1, 4);
        Debug.Log(randomNumber);
        randomNumber = 1;

        if ((randomNumber == 1) && (collision.gameObject.name == "RightSmallObstacles"))
        {
            transform.position = new Vector3(5f, 0f, 15f); //(-5.8,0.9,15.2)
        }
        if ((randomNumber == 2) && (collision.gameObject.name == "RightSmallObstacles"))
        {
            transform.position = new Vector3(5f, 0f, -14f); //(5.9, 0.8, -14.2)
        }
        if (randomNumber == 3)
        {
            box = GameObject.FindGameObjectWithTag("RightSmallObstacles");
            box.GetComponent<BoxCollider>().enabled = false;
        }
        box.GetComponent<BoxCollider>().enabled = true;
    }
}

