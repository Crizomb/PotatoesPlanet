using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GlobalLogic : MonoBehaviour
{
    [SerializeField] private Wave1 wave1;
    [SerializeField] private GameObject WaveRelatedUI;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Image waveImage;

    public int numberKilled = 0;

    // Start is called before the first frame update
    public void StartWave()
    {
        wave1.StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "score : "+numberKilled;
    }
}
