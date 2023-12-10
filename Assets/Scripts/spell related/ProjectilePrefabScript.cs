using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePrefabScript : gravityAffectedObject
{
    public bool isBeingCast = false;

    public Transform playerTransform;
    public Vector3 spawnPosition;

    private float timeCast = 0f;
    public float maxCastTime = 3f;
    public float baseDamage = 10f;

    private damageHolder damageHolder;

    void Start()
    {
        base.Start();
        
        damageHolder = GetComponentInParent<damageHolder>();
        if (damageHolder == null)
        {
            Debug.Log("No damage holder found");
            Start();
        }
    }

    private void Update()
    {
        base.Update();
        if (isBeingCast)
        {
            FollowPlayer();
            timeCast += Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1) * spellMagnitude(timeCast)/2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void FollowPlayer()
    {
        if (rb == null)
        {
            return;
        }

        transform.position = playerTransform.position + playerTransform.rotation * spawnPosition;

        transform.rotation = playerTransform.rotation;
    }

    public void Launch(Vector3 magnitude)
    {
        damageHolder.damage = (int)(baseDamage * spellMagnitude(timeCast));
        rb.velocity = magnitude*spellMagnitude(timeCast);
    }

    private float spellMagnitude(float t)
    {
        return (1 - Mathf.Exp(-t / (4 * maxCastTime))) * 2;
    }
}
