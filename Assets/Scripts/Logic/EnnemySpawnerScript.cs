using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawnerScript : MonoBehaviour
{
    
    public void Spawn(GameObject ennemyPrefab)
    {
        Instantiate(ennemyPrefab, transform.position+Vector3.down, transform.rotation);
    }
}
