using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderAI : MonoBehaviour {

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

            if (isWandering == false)
            {
                StartCoroutine(wander());
            }
            if (isRotatingRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }
            if (isRotatingLeft == true)
            {
                transform.Rotate(transform.right * Time.deltaTime * -rotSpeed); //rotate in the opposite side
            }
            if (isWalking == false)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
    }

    IEnumerator wander(){
        int rotTime = Random.Range(1, 3); //amount of time in between it will be rotating
        int rotateWait = Random.Range(1, 4); //waiting time
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);//time it will be walking 

        isWandering = true;

        yield return new WaitForSeconds(walkWait); //waits for a random number
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if(rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;

    }

}
