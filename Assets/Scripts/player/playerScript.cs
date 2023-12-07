using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : gravityAffectedObject
{
    public InputHandler inputHandler;
    public ProjectileSpell projSpell;
    public float moveForce = 5f;
    public float jumpForce = 5f;
    public int baseHealth = 100;

    // Start is called before the first frame update

    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Movement();
        base.Update();
        Spell_manager();
    }

      // ------------------//
     //       Movement    //
    // ----------------- //

    Boolean isGrounded()
    {
        return Physics.Raycast(transform.position, transform.rotation * Vector3.down, 1.1f);
    }

    void Jump()
    {
        if (inputHandler.getJump() && isGrounded())
        {
            base.rb.AddForce(transform.rotation * Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Movement()
    {
        float horizontal_input = inputHandler.movementInput.x;
        float vertical_input = inputHandler.movementInput.y;
        float localmoveForce = moveForce;

        if (! isGrounded())
        {
            localmoveForce = moveForce / 2;
        }

        Vector3 movement_force = new Vector3(horizontal_input, 0f, vertical_input).normalized * localmoveForce;
        base.rb.AddForce(transform.rotation * movement_force);

    }

    // ------------//
    // Other input //
    // ----------- //

    void Spell_manager()
    {
        if (inputHandler.getFire())
        {
            projSpell.CastEffect(transform);
        }
    }

    

    // -------------------//
    // Damage and Healing //
    // -----------------  //

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            baseHealth -= 10;
            Debug.Log("Player Health: " + baseHealth);
        }
    }

}
