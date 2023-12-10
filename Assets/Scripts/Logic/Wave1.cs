using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : Wave
{
    [SerializeField] GlobalLogic logicScript;
    [SerializeField] GameObject ennemyPrefab;
    float timeBetweenSpawn = 5f;
    

    void Start()
    {
        base.waveNumber = 1;
        base.WaveActive = false;
        base.MaxEnnemyNumber = 10000;
    }

    public void Update()
    {
        timeBetweenSpawn = 5f / (1 + logicScript.numberKilled/50f);
    }

    public void StartWave()
    {
        base.StartWave();
    }


    protected override bool StopWaveCondition()
    {
        return base.currentEnnemySpawned >= base.MaxEnnemyNumber;
    }

    protected override void WaveEffect()
    {
        if (base.timer > timeBetweenSpawn)
        {
            ennemySpawnerScript.Spawn(ennemyPrefab);
            
            base.timer = 0f;
            base.currentEnnemySpawned++;
        }
    }

}
