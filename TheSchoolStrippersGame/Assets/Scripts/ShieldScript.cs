using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField]
    Vector2 impulseForce;
    public void ActivateShield()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        this.gameObject.transform.parent = null;
        
        rb.simulated = true;

        Vector2 impulse = new Vector2(impulseForce.x * Random.Range(1, 1.3f), impulseForce.y * Random.Range(1, 1.3f));

        rb.AddForce(impulse, ForceMode2D.Impulse);

        
    }
}
