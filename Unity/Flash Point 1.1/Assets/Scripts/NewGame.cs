using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("FireFighter").SetActive(false);


        activateGameObject(3);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F1))
        {
            GameObject.Find("FireFighter").SetActive(true);

            GameObject.Find("Victim2").SetActive(true);

        }*/
    }

    void activateGameObject(int val)
    {
        for (int i = 1; i <= 28; i++)
        {
            if (i == val)
            {
                GameObject.Find("Victim" + val).SetActive(true);
               // GameObject.Find("Victim" + val).transform.localScale = new Vector3(0.7f, 0.3f, 0.7f);
            }
            else
            {
                GameObject.Find("Victim" + i).SetActive(false);
                //GameObject.Find("FireFighter"+i).GetComponent<Move>().enabled= false;
            }
        }
        Console.WriteLine("Victim" + val);
    }

}
