using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPowerUp : MonoBehaviour
{
    [SerializeField] int powerUpAmount = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
         {
            ScoringSystem.thePoints += powerUpAmount;
            Destroy(this.gameObject);
        }
    }
    
}
