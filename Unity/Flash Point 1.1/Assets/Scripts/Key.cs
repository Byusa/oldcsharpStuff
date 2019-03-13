using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            //if (collision.gameObject.CompareTag("Door")){
            Destroy(collision.gameObject);
            print("yes");
        }
    }
    /*void OnTriggerEnter(Collider other)
     {
         //if tagged Pick Up it will destroy it
         if (other.gameObject.CompareTag("Door"))
         {
             other.gameObject.SetActive(false);
            print("No");

        }
    }*/
}
