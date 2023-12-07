using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    [SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField]
    float distance_from_sender = 2f;
    [SerializeField]
    float launch_speed = 10f;

    [SerializeField]
    float cooldown_ = 1f;
    [SerializeField]
    int manaCost_ = 10;
    [SerializeField]
    int damage_ = 10;


    public void Start()
    {
        manaCost = manaCost_;
        damage = damage_;
        cooldown = cooldown_;
    }



    public override void CastEffect(Transform sender)
    {
        GameObject projectile = Instantiate(ProjectilePrefab);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        damageHolder damageHolder = projectile.GetComponent<damageHolder>();
        damageHolder.damage = damage;
        projectile.transform.position = sender.position + sender.forward * distance_from_sender;
        rb.rotation = Quaternion.LookRotation(sender.forward);
        rb.velocity = sender.forward * launch_speed;
    }
}
