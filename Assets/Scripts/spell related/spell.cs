using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    protected int manaCost;
    protected int damage;
    protected float cooldown;
    protected float cooldownTimer;


    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public abstract void CastEffect(Transform sender);

    public void Cast(Transform sender)
    {
        if (cooldownTimer <= 0)
        {
            CastEffect(sender);
            cooldownTimer = cooldown;
        }
    }

}
