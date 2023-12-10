using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] public static EnnemySpawnerScript ennemySpawnerScript;
    [HideInInspector] public bool WaveActive = false;
    protected int waveNumber;
    protected float timer = 0f;
    protected int MaxEnnemyNumber = 0;
    protected int currentEnnemySpawned = 0;
    

    private void Awake()
    {
        ennemySpawnerScript = GameObject.Find("EnnemySpawner").GetComponent<EnnemySpawnerScript>();
        if (ennemySpawnerScript == null)
        {
            Debug.LogError("EnnemySpawnerScript not found");
            throw new System.Exception("EnnemySpawnerScript not found");

        }
    }

    private void FixedUpdate()
    {
        if (WaveActive)
        {
            WaveEffect();
            timer += Time.fixedDeltaTime;
            if (StopWaveCondition())
            {
                EndWave();
            }
        }
    }

    protected abstract void WaveEffect();
    protected abstract bool StopWaveCondition();

    public void StartWave()
    {
        WaveActive = true;
    }
    public void EndWave()
    {
        WaveActive = false;
    }
}
