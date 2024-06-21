using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;


    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth/100;
    }

    private void Update()
    {
        currenthealthBar.fillAmount=playerHealth.currentHealth/100;
    }
}

