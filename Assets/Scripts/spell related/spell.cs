using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    protected int manaCost;
    protected float damage;

    public float timeCasting = 0f;
    private bool isCasting = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCasting)
        {
            timeCasting += Time.deltaTime;
        }
    }

    public abstract void StartCastEffect(Transform sender);
    public abstract void StopCastEffect(Transform sender);

    public void StartCast(Transform sender)
    {
        StartCastEffect(sender);
        isCasting = true;

    }

    public void StopCast(Transform sender)
    {
        StopCastEffect(sender);
        isCasting = false;
        timeCasting = 0f;
    }

}
