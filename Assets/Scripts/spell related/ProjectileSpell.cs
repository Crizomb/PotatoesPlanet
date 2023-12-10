using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    [SerializeField] private GameObject logic;
    private SkillPointsScript skillPointsScript;

    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float launch_speed_base = 10f;
    float launch_speed;

    [SerializeField] float cooldown_ = 1f;
    [SerializeField] int manaCost_ = 10;
    [SerializeField] float damage_ = 10;

    [SerializeField] float maxCastTime = 3f;

    [SerializeField]
    Vector3 spawnPosition = new Vector3(0, 0.2f, 1);

    private GameObject current_projectile;
    private Rigidbody current_projectile_rb;
    private ProjectilePrefabScript current_projectile_script;



    public void Start()
    {
        skillPointsScript = logic.GetComponent<SkillPointsScript>();
        if (skillPointsScript == null)
        {
            throw new Exception("SkillPointsScript not found");
        }
        manaCost = manaCost_;
        damage = damage_;
    }

    public void Update()
    {
        launch_speed = launch_speed_base * (1 + ((float)skillPointsScript.projectileSpeedLevel - 1f) / 10f);
    }



    public override void StartCastEffect(Transform sender)
    {
        current_projectile = Instantiate(ProjectilePrefab);
        current_projectile_rb = current_projectile.GetComponent<Rigidbody>();

        current_projectile_script = current_projectile.GetComponent<ProjectilePrefabScript>();
        current_projectile_script.playerTransform = sender;
        current_projectile_script.spawnPosition = spawnPosition;
        current_projectile_script.isBeingCast = true;
        current_projectile_script.maxCastTime = maxCastTime;
        current_projectile_script.baseDamage = damage*(launch_speed/launch_speed_base);


    }

    public override void StopCastEffect(Transform sender)
    {
        if (current_projectile_rb == null)
        {
            return;
        }
        SoundManager.Instance.PlayShootSound();
        current_projectile_script.isBeingCast = false;
        current_projectile_rb.isKinematic = false;
        current_projectile_rb.rotation = Quaternion.LookRotation(sender.forward);
        current_projectile_script.Launch(sender.forward * launch_speed);

    }
}
