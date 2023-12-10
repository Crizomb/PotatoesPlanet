using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour { 

    public float rotationSpeed = 10.0f;
    public bool jumpInput { get; private set; }

    public bool fireInputDown { get; private set; }

    public bool fireInputUp { get; private set; }
    public Vector2 movementInput { get; private set; }

    public Vector2 mouseInput { get; private set; }


    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        jumpInput = Input.GetButtonDown("Jump") || jumpInput;
        fireInputDown = Input.GetButtonDown("Fire1") || fireInputDown;
        fireInputUp = Input.GetButtonUp("Fire1") || fireInputUp;
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

    public bool getFireDown()
    {
        bool input_valor = fireInputDown;
        fireInputDown = false;
        return input_valor;
    }

    public bool getFireUp()
    {
        bool input_valor = fireInputUp;
        fireInputUp = false;
        return input_valor;
    }

    void RotateWithMouse()
    {
        transform.Rotate(Vector3.up * mouseInput.x * rotationSpeed);
    }
}
