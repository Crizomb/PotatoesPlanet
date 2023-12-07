using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloattingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [HideInInspector] public float health;
    [HideInInspector] public float maxHealth;

    private Camera mainCamera;

    private void Start()
    {
        // mainCamera has tag MainCamera
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        healthBar.value = health/maxHealth;
        transform.rotation = mainCamera.transform.rotation;
    }
}
