using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public static float xForce;
    public Transform shott;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            Instantiate(bullet, transform.position, Quaternion.identity);
       
        if (Input.GetKey(KeyCode.Space))
        {
            xForce += 0.2f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(shott, transform.position, transform.rotation);
            Instantiate(bullet, transform.position, Quaternion.identity);

        }
 
    }
}
