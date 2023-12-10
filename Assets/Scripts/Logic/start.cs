using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField] private GameObject logic;
    private GlobalLogic globalLogic;

    void Start()
    {
        globalLogic = logic.GetComponent<GlobalLogic>();
        
    }

    private void OnDestroy()
    {
        SoundManager.Instance.PlayStartSound();
        SoundManager.Instance.PlayBackgroundMusic();
        globalLogic.StartWave();
    }
}
