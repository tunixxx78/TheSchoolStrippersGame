using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 4;
    private int currentHealth;
    public event Action<float> OnHealthPctChanged = delegate { };

    private GameObject score;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }
    void Update()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoringSystem>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-1);
        }
        if(currentHealth <= 0)
        {
            Debug.Log("Voitit pelin");
        }

    }
}
