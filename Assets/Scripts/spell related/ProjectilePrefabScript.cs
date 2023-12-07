using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePrefabScript : gravityAffectedObject
{
    private void OnCollisionEnter(Collision collision)
    {
        // Delete object
        Destroy(this.gameObject);
    }
}
