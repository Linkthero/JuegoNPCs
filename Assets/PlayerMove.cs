using System.Windows.Input;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private float movespeed = 5f;
    private Vector2 movement;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement.Set(InputManager.Movement.x, InputManager .y);
        rb.linearVelocity = movement * movespeed;
    }

    void OnMove(InputValue input)
    {
        movement.x = input.Get<Vector2>().x;
        movement.y = input.Get<Vector2>().y;
    }
}
