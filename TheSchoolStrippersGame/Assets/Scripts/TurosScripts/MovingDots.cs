using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDots : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Animator dotAnimator;
    private bool onBeatSpot = false;
    [SerializeField] GameObject text;

    private void Update()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);
        DotIsClicked();
    }

    public void DotIsBeatSpoted()
    {
        onBeatSpot = true;
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
        if (collision.tag == "BeatSpot")
        {
            DotIsBeatSpoted();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BeatSpot")
        {
            onBeatSpot = false;
        }
    }

    public void DotIsClicked()
    {
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("BlueDot"))
            {
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                
            }
        }
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("RedDot"))
            {
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

            }
        }
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("GreenDot"))
            {
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

            }
        }
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("YellowDot"))
            {
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

            }
        }
    }
}
