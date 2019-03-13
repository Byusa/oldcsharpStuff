using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class PlayerBall : MonoBehaviour
{

    float moveSpeed = 6;
    float gravity = -20;
    Vector3 velocity;

    Controller controller;

    void Start()
    {
        controller = GetComponent<Controller>();
    }

    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}