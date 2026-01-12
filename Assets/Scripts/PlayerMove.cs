using System.Windows.Input;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private float movespeed = 5f;
    private Vector3 movement;
    private Rigidbody rb;

    //Movimiento de camara
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

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
        MoverCamaraConRaton();
    }

    void OnMove(InputValue input)
    {
        movement.x = input.Get<Vector2>().x;
        movement.z = input.Get<Vector2>().y;
    }

    private void MoverCamaraConRaton()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical (pitch)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita la vista arriba/abajo
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal (yaw)
        transform.Rotate(Vector3.up * mouseX);
    }
}
