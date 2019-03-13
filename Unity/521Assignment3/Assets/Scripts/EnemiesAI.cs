using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAI : MonoBehaviour {

    public int maxValue = 1;
    public int minValue = -1;
    public float currentValue = 0;
    public int direction = 1;
    public float speed = 10.0f;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentValue += (Time.deltaTime * direction);

        if (currentValue >= maxValue)
        {
            direction *= -1;
            currentValue = maxValue;

        }
        else if (currentValue <= minValue)
        {
            direction *= -1;
            currentValue = minValue;
        }
        transform.position = new Vector3(currentValue * speed, 0, 0);
        //transform.Translate(0, 0, currentValue);
    }
}
