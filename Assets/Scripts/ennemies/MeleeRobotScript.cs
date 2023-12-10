using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRobotScript : gravityAffectedObject
{


    [SerializeField] public FloattingHealthBar floattingHealthBar;
    
    [SerializeField] public int maxHealth;
    private int health;
    [SerializeField] public float moveSpeed = 3f;

    [SerializeField] public int baseDamage = 10;
    public damageHolder damageHolder;

    private Transform playerTransform;
    private GlobalLogic globalLogic;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        floattingHealthBar.maxHealth = maxHealth;
        health = maxHealth;
        damageHolder = GetComponent<damageHolder>();
        damageHolder.damage = baseDamage;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (playerTransform == null)
        {
            Debug.Log("Not found player transform");
        }

        globalLogic = GameObject.Find("Logic").GetComponent<GlobalLogic>();
        if (globalLogic == null)
        {
            Debug.Log("Not found global logic");
            throw new System.Exception("Not found global logic");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.Update();
        floattingHealthBar.health = health;
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 vec_diff = playerTransform.position - transform.position;
        vec_diff.Normalize();
        Vector3 vec_diff_on_ennemy_plan = Vector3.ProjectOnPlane(vec_diff, transform.up);
        transform.forward = vec_diff_on_ennemy_plan.normalized;
        base.rb.velocity = transform.forward * moveSpeed * (1+(float)globalLogic.numberKilled/50f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        damageHolder damageHolder = collision.gameObject.GetComponent<damageHolder>();
        if (damageHolder != null && collision.gameObject.tag != "Ennemy")
        {
            health -= damageHolder.damage;
            rb.AddForce((transform.up*0.5f-transform.forward)*10f, ForceMode.Impulse);
            if (health <= 0)
            {
                globalLogic.numberKilled++;
                SoundManager.Instance.PlayKillSound();
                Destroy(this.gameObject);
            }
        }
    }
}
