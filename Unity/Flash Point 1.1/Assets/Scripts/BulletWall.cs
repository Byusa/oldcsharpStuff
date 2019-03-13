using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")){ 
        //if (collision.gameObject.name == "Wall")

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
