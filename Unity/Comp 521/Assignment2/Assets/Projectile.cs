using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform target;
    public Transform throwPoint;
    //public float speed;
    //public float lifeTime;
    public GameObject ball;
    public float timrTillHit = 1f;

    //public float xVelo, yVelo;

	// Update is called once per frame
	void Start () {
        //transform.Translate(transform.right * speed * Time.deltaTime);
        Throw();
	}
    /*void Throw(){
        GameObject bulletInstance = Instantiate(ball, throwPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(xVelo, yVelo);
    }*/
    void Throw(){
        float xdistance;
        xdistance = target.position.x - throwPoint.position.x;

        float ydistance;
        ydistance = target.position.y - throwPoint.position.y;

        float throwAngles; //in radian

        throwAngles = Mathf.Atan((ydistance + 4.985f) / xdistance);//the angle

        float totalVelo = xdistance / Mathf.Cos(throwAngles);

        float xVelo, yVelo;

        xVelo = totalVelo * Mathf.Cos(throwAngles);
        yVelo = totalVelo * Mathf.Sin(throwAngles);

        GameObject bulletInstance = Instantiate(ball, throwPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(xVelo, yVelo);

    }
}
