using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRobotScript : gravityAffectedObject
{
    [SerializeField] public FloattingHealthBar floattingHealthBar;
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        floattingHealthBar.maxHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.Update();
        floattingHealthBar.health = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        damageHolder damageHolder = collision.gameObject.GetComponent<damageHolder>();
        if (damageHolder != null)
        {
            health -= damageHolder.damage;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
