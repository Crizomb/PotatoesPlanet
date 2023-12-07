using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour { 

    public float rotationSpeed = 10.0f;
    public bool jumpInput { get; private set; }

    public bool fireInput { get; private set; }
    public Vector2 movementInput { get; private set; }

    public Vector2 mouseInput { get; private set; }


    void Update()
    {
        jumpInput = Input.GetButtonDown("Jump") || jumpInput;
        fireInput = Input.GetButtonDown("Fire1") || fireInput;
        movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        RotateWithMouse();
    }

    public bool getJump()
    {
        bool input_valor = jumpInput;
        jumpInput = false;
        return input_valor;
    }

    public bool getFire()
    {
        bool input_valor = fireInput;
        fireInput = false;
        return input_valor;
    }

    void RotateWithMouse()
    {
        // Lock the cursor to the center of the screen
        //Cursor.lockState = CursorLockMode.Locked;


        transform.Rotate(Vector3.up * mouseInput.x * rotationSpeed);

    }
}
