using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPowerUp : MonoBehaviour
{
    public int powerUpAmount;
    public Combo combo;


    private void Start()
    {
        combo = FindObjectOfType<Combo>();
        powerUpAmount = combo.bonusComboAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
         {
            //ScoringSystem.thePoints += powerUpAmount;
            ScoringSystem.theScore += powerUpAmount;
            FindObjectOfType<Combo>().BonusComboBar();
            Destroy(this.gameObject);
        }
    }
    
}
