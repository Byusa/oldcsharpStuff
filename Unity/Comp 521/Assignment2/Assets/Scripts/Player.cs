using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;
    private Vector2 startPosition;
    private Vector2 newPosition;

    [SerializeField] private int speed = 10;
    [SerializeField] private int maxDistance = 200;
    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller controller;

    void Start()
    {
        controller = GetComponent<Controller>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
           // velocity.y = jumpVelocity;
        
          //transform.position = new Vector2(transform.position.x + maxDistance * Mathf.Sin(Time.time * speed), transform.position.y);
       
        
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}