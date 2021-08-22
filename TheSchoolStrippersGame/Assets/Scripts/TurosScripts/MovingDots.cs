using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDots : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Animator dotAnimator;

    private void Update()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DotDestroyer"))
        {
            dotAnimator.SetTrigger("DotDeath");
            Destroy(this.gameObject, 2f);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BeatSpot" && Input.GetMouseButton(0))
        {   
                dotAnimator.SetTrigger("DotWinning");
                Destroy(this.gameObject, 4f);
            
        }
    }
}
