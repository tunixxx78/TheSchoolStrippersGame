using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPowerUp : MonoBehaviour
{
    public int powerUpAmount = 500;
    public Combo combo;


    private void Start()
    {
        combo = FindObjectOfType<Combo>();
        powerUpAmount = combo.bonusComboAmount;
    }

    private void Update()
    {
        if (transform.position.y <= -7)
        {
            Destroy(this.gameObject);
        }
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
