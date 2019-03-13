using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //FireFighter fireFighter = new FireFighter();
    //public int count2;

    void Start()
    {
        //count2 = fireFighter.Count;
    }


     // Use this for initialization

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            //if (collision.gameObject.CompareTag("Door")){
            Destroy(collision.gameObject);

            // FireFighter fireFighter = new FireFighter();
            //fireFighter.Count--;
            //count2--;
            //print(fireFighter.Count);
            //print(count2);
            //fireFighter.SetCountText();
            //System.Console.Write(fireFighter.Count);
            //print("yes");
        }
       
    }
}
