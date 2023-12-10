using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScript : gravityAffectedObject
{
    public InputHandler inputHandler;
    public ProjectileSpell projSpell;

    public float baseMoveForce;
    private float moveForce;


    public float jumpForce;
    public float baseHealth;
    public float healingRate;

    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject logic;
    private SkillPointsScript skillPointsScript;
    public float health;




    // Start is called before the first frame update

    void Start()
    {
        base.Start();
        skillPointsScript = logic.GetComponent<SkillPointsScript>();
        if (skillPointsScript == null)
        {
            throw new Exception("SkillPointsScript not found");
        }
        health = baseHealth;
    }

    void FixedUpdate()
    {
        moveForce = baseMoveForce * (1+((float)skillPointsScript.speedLevel-1f)/10f);

        base.Update();
        Jump();
        Movement();
        Spell_manager();
        HealthBar();
        CheckDeath();
        Healing();
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
        if (inputHandler.getFireDown())
        {
            projSpell.StartCast(transform);
        }

        if (inputHandler.getFireUp())
        {
            projSpell.StopCast(transform);
        }
    }



    // -------------------//
    // Damage and Healing //
    // -----------------  //

    private void OnCollisionStay(Collision collision)
    {
        damageHolder damageHolder = collision.gameObject.GetComponent<damageHolder>();
        if (damageHolder != null)
        {
            health -= damageHolder.damage;
            base.rb.AddForce(-transform.forward * 10f, ForceMode.Impulse);
            if (health <= 0)
            {
                NotImplementedException e = new NotImplementedException();
            }
        }
    }

    void Healing()
    {
        health += healingRate * Time.fixedDeltaTime;
        if (health > baseHealth)
        {
            health = baseHealth;
        }
    }

    void CheckDeath()
    {
        if (health <= 0)
        {
            SoundManager.Instance.PlayDeathSound();
            SceneManager.LoadScene("GameOver");
        }
    }

    // -------------------//
    // Health Bar         //
    // -----------------  //

    void HealthBar()
    {
          healthBar.value = (float) health / baseHealth;
    }

}
