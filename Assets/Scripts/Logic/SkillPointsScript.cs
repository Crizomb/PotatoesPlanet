using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillPointsScript : MonoBehaviour
{
    private int skillPoints = 0;
    private int usedSkillPoints = 0;

    public int speedLevel = 1;
    public int projectileSpeedLevel = 1;


    [SerializeField] private GlobalLogic globalLogic;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Slider projectileSpeedSlider;

    [SerializeField] private TextMeshProUGUI skillPointsText;

    private TextMeshProUGUI speedText;
    private TextMeshProUGUI projectileSpeedText;



    // Start is called before the first frame update
    void Start()
    {
        speedText = speedSlider.GetComponentInChildren<TextMeshProUGUI>();
        projectileSpeedText = projectileSpeedSlider.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkillValues();
        UpdateSlider();
        UpdateSkillPoints();
    }

    void UpdateSkillPoints()
    {
        skillPoints = globalLogic.numberKilled - usedSkillPoints + 5;
        skillPointsText.text = "Points de compétence disponible : " + skillPoints;
    }


    void UpdateSkillValues()
    {
        UpdateSkillValues_constructor(speedSlider, ref speedLevel);
        UpdateSkillValues_constructor(projectileSpeedSlider, ref projectileSpeedLevel);
    }

    void UpdateSlider()
    {
        UpdateSliderConstructor(speedSlider, speedLevel, speedText, "Vitesse du joueur : ");
        UpdateSliderConstructor(projectileSpeedSlider, projectileSpeedLevel, projectileSpeedText, "Vitesse des projectiles : ");

    }

    void UpdateSkillValues_constructor(Slider slider, ref int valueLevel)
    {

        int new_value = (int)slider.value;
        int difference = new_value - valueLevel;
        if (skillPoints >= difference)
        {
            usedSkillPoints += difference;
            valueLevel = new_value;
        }
    }

    public void UpdateSliderConstructor(Slider slider, int element_value, TextMeshProUGUI slider_text, string base_text)
    {
        slider.value = element_value;
        slider_text.text = base_text + element_value;
    }

}

