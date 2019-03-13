using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTrial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //FireFighter fireFighter = new FireFighter();
        //System.Console.Write(fireFighter.CountText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //new openDoor
    /*void OpenDoor1()
    {
        //Create the bullet from the prefab
        GameObject bullet = (GameObject)Instantiate(bulletPrefab);

        //Ignore colision
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
        bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles; //turn from angle to 3d

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }*/
}
