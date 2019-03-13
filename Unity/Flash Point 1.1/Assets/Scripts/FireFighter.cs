using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for the text

public class FireFighter : MonoBehaviour
{
    public Text countText; //countText
    public Text NoAPText; // public Text NoAPText; 
    public Text doorDestroyedCountText; //countText
    public Text wallDestroyedCountText; //countText
    public GameObject bulletDoorPrefab; // for the spawn(gun) for the door
    public GameObject bulletWallPrefab;
    public Transform bulletDoorSpawn; //for the bullet   for door
    public Transform bulletWallSpawn;
    public float rotationSpeed = 10.0f;//bulletSpeed
    public float bulletSpeed = 10.0f;//bulletSpeed
    public float lifeTime = 3;
    public const float stepDuration = 0.5f;


    private Coroutine playerMovement;
    private int StartDoorNum;
    private int StartWallNum;
    private int count;
    private int doorDestroyedCount;
    private int wallDestroyedCount;



    /*public Text CountText
    {
        get { return countText; }
        set
        {
            //if ((value > 0) && (value < 13)){
            countText = value;
            //}
            }
    }

    public int Count
    {
        get { return count;}
        set
        {
            //if ((value > 0) && (value < 13)){
            count = value;
            //}
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {

        count = 50;
        SetCountText();

        doorDestroyedCount = 0;
        SetdoorDestroyedCount();

        wallDestroyedCount = 0;
        SetWallDestroyedCount();

        StartDoorNum = GameObject.FindGameObjectsWithTag("Door").Length;
        StartWallNum = GameObject.FindGameObjectsWithTag("Wall").Length;

        //GameObject.Find("FireFighter").transform.position = new Vector3(3.21f, 0.82f, 5.12f);

        //GameObject.Find("FireFighter").SetActive(false);
        //GameObject.Find("FireFighter").transform.position = new Vector3(2.21f, 0.82f, 5.12f);

        //Starting position of the victims 
        int i = 1;
        int j = 2;

        float x1 = RandomXPositionGenerator();
        float y1 = RandomYPositionGenerator();
        float z1 = RandomZPositionGenerator();
        GameObject.Find("Victim" + i).transform.position = new Vector3(x1, 0.82f, 3.12f);
        float x2 = RandomXPositionGenerator();
        float y2 = RandomYPositionGenerator();
        float z2 = RandomZPositionGenerator();

        float x3 = RandomXPositionGenerator();
        float y3 = RandomYPositionGenerator();
        float z3 = RandomZPositionGenerator();

        while ((int)x1 + (int)y1 + (int)z1 == (int)x2 + (int)y2 + (int)z2) {
            x2 = RandomXPositionGenerator();
            y2 = RandomYPositionGenerator();
            z2 = RandomZPositionGenerator();
        }
        GameObject.Find("Victim" + j).transform.position = new Vector3(x2, 0.82f, 3.12f);

        while (
               ((int)x1 + (int)y1 + (int)z1 == (int)x3 + (int)y3 + (int)z3) ||
               ((int)x2 + (int)y2 + (int)z2 == (int)x3 + (int)y3 + (int)z3)
               ) {
            x2 = RandomXPositionGenerator();
            y2 = RandomYPositionGenerator();
            z2 = RandomZPositionGenerator();
        }
        GameObject.Find("Victim3").transform.position = new Vector3(x3, 0.82f, 3.12f);



        if (GameObject.Find("Victim1").activeSelf) {
            print("Active");
        }
        else {
            print("You are fooling yourself");
        }

    }

    // Update is called once per frame
    private void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.F1))
        {
            GameObject.Find("FireFighter").transform.position = new Vector3(3.21f, 0.82f, 5.12f);

            //GameObject.Find("FireFighter").SetActive(true);

            //GameObject.Find("Victim2").SetActive(true);

        }*/

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100.0f))
            {

                if (hit.transform != null)
                {
                    print(hit.transform.gameObject.name);
                }

                /*if (hit.transform.name == "Pos1")
                {
                    Debug.Log("This is a Player");
                    //GameObject.Find("FireFighter").transform.position = new Vector3(3.21f, 0.82f, 5.12f);
                }
                else
                {
                    Debug.Log("This isn't a Player");
                }*/
            }
            else
            {
                Debug.Log("not hi");

            }
        }





        //Moving
        if (playerMovement == null)
        {
            //guys, In general not a good idea to use Input.GetKey; use Input.GetButton instead
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.RightArrow))
            {
                if (count >= 1)
                {
                    Vector3 startPosition = transform.position;
                    playerMovement = StartCoroutine(Move(Vector3.forward));
                    Vector3 destinationPosition = transform.position + Vector3.forward;
                    if (startPosition != destinationPosition) {
                        count--;
                    }
                    SetCountText();
                }
                else
                {
                    SetNoAPText();
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (count >= 1)
                {
                    Vector3 startPosition = transform.position;
                    playerMovement = StartCoroutine(Move(Vector3.back));
                    Vector3 destinationPosition = transform.position + Vector3.back;
                    if (startPosition != destinationPosition)
                    {
                        count--;
                    }
                    SetCountText();
                }
                else
                {
                    SetNoAPText();
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow))
            {
                if (count >= 1)
                {
                    Vector3 startPosition = transform.position;
                    playerMovement = StartCoroutine(Move(Vector3.right));
                    Vector3 destinationPosition = transform.position + Vector3.right;
                    if (startPosition != destinationPosition)
                    {
                        count--;
                    }
                    SetCountText();
                }
                else
                {
                    SetNoAPText();
                }
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow))
            {
                if (count >= 1)
                {
                    Vector3 startPosition = transform.position;
                    playerMovement = StartCoroutine(Move(Vector3.left));
                    Vector3 destinationPosition = transform.position + Vector3.left;
                    if (startPosition != destinationPosition)
                    {
                        count--;
                    }
                    SetCountText();
                }
                else
                {
                    SetNoAPText();
                }
            }
        }

        //Turning in directions
        if (Input.GetKeyDown("return"))
        {
            transform.Rotate(0, 90, 0);
        }

        //GameObject Door = GameObject.FindGameObjectsWithTag("Door");

        /////////////////////////////////////////////////Opening the door /////////////////////////////////////////////////
        //Space for opening the door
        if (Input.GetKeyDown("space"))
        {
            //GameObject.Find("Door").SetActive(false);
            // Instantiate(remains, transform.position, transform.rotation);
            FireTheDoor();

            int currentDoorNum = GameObject.FindGameObjectsWithTag("Door").Length;
            print("Start Door Number " + StartDoorNum);
            print("Current Door Number " + currentDoorNum);
            if (currentDoorNum != StartDoorNum) {
                doorDestroyedCount++;
                count--;
                SetCountText();
                StartDoorNum = currentDoorNum;
            }

            //count--;
            //SetCountText();
        }

        /////////////////////////////////////////////////Chopping the walls /////////////////////////////////////////////////
        //click tab To break the wall
        if (Input.GetKeyDown("tab"))
        {
            FireTheWall();
            //CurrentwallNumber = GameObject.FindGameObjectsWithTag("wall").Length;
            //Debug.Log("CurrentwallNumber " + CurrentwallNumber);
            //if(PreviouswallNumber> CurrentwallNumber)
            // {
            int currentWallNum = GameObject.FindGameObjectsWithTag("Wall").Length;
            print("Start Door Number " + StartWallNum);
            print("Current Door Number " + currentWallNum);
            if (currentWallNum != StartWallNum)
            {
                wallDestroyedCount++;
                count = count - 2;
                SetCountText();
                StartWallNum = currentWallNum;
            }
            // }
            //PreviouswallNumber = CurrentwallNumber;
        }


    }

    //the move enum
    private IEnumerator Move(Vector3 direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 destinationPosition = transform.position + direction;
        float t = 0.0f;

        if (!Physics.Linecast(startPosition, destinationPosition) && Physics.Linecast(destinationPosition, destinationPosition + Vector3.down * 3.0f))
        {
            while (t < 1.0f)
            {
                transform.position = Vector3.Lerp(startPosition, destinationPosition, t);
                t += Time.deltaTime / stepDuration;
                yield return new WaitForEndOfFrame();
            }

            transform.position = destinationPosition;
        }

        playerMovement = null;
    }

    //Updating the count
    public void SetCountText()
    {
        countText.text = "Action Points: " + count.ToString();
    }
    public void SetdoorDestroyedCount()
    {
        doorDestroyedCountText.text = "Number of Doors Destroyed: " + doorDestroyedCount.ToString();
    }
    public void SetWallDestroyedCount()
    {
        wallDestroyedCountText.text = "Number of Wall Destroyed: " + wallDestroyedCount.ToString();
    }

    void SetNoAPText()
    {
        countText.text = "Sorry, You have only " + count.ToString() + " Action Points";
    }


    //this method is for shooting bullets to open the doors
    void FireTheDoor()
    {
        //Create the bullet from the prefab
        GameObject bullet = (GameObject)Instantiate(bulletDoorPrefab, bulletDoorSpawn.position, bulletDoorSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

        //bullet the bullet after a second 
        Destroy(bullet, 0.1f);
    }

    //this method is for shooting bullets to break the wall
    void FireTheWall()
    {
        //Create the bullet from the prefab
        GameObject bullet = (GameObject)Instantiate(bulletWallPrefab, bulletWallSpawn.position, bulletWallSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

        //bullet the bullet after a second 
        Destroy(bullet, 0.1f);
    }
    //for the bullet
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    private float RandomXPositionGenerator()
    {
        float x = 0.0f;
        float rand = Random.Range(-3.0f, 2.0f);
        int randInt = (int)rand;
        x = (float)randInt + 0.0f;

        return x;
    }
    private float RandomYPositionGenerator()
    {
        float y = 0.0f;
        float rand = Random.Range(-10.0f, 10.0f);
        int randInt = (int)rand;
        y = (float)randInt + 0.82f;

        return y;
    }
    private float RandomZPositionGenerator()
    {
        float z = 0.0f;
        float rand = Random.Range(-10.0f, 10.0f);
        int randInt = (int)rand;
        z = (float)randInt + 0.82f;

        return z;
    }

    private string [] choose3RandomPOI()
    {
        string[] ThreePOI = new string[3];

        ThreePOI[0] = choose1RandomPOI();
        ThreePOI[1] = choose1RandomPOI();
        ThreePOI[2] = choose1RandomPOI();
        return ThreePOI;
    }

    //choose one randomPOI (it can be victim or falseAlarm)
    private string choose1RandomPOI(){
        string Victim = "Victim1";
        string FalseAlarm = "";
        float rand = Random.Range(1.0f, 15.0f);
        int randInt = (int)rand;
        if (randInt >= 1 || randInt <= 10) 
        {
            Victim = "Victim" + randInt;
            return Victim;
        } else if ((randInt >= 11 || randInt <= 15))
        {
            FalseAlarm = "FalseAlarm" + randInt;
            return FalseAlarm;
        }
        return Victim;
            //GameObject.Find("Victim" + i).transform.position = new Vector3(x1, 0.82f, 3.12f);
    }
    /*public Transform other;

    void Example()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);
        }
    }*/

    //List of methods according to the design

    //void MoveVictim(Victim) {}
    //getControlledBy(){}
    //setControlledBy(P: Player){}
    //SetRole(rk: RoleKind)
    //extinguishFire(destination: Space){}
    //getSpace(){}



}



//To be fixed
//1. When the hits the wall it still count (proposed soln: check the postions before counting)