using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledAgent : MonoBehaviour {
    public float speed= 8.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
        moveDir.z = Input.GetAxis("Vertical"); // get result of WS keys in Z
                                               // move this object at frame rate independent speed:
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
