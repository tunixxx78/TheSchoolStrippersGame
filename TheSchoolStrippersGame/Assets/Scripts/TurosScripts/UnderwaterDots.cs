using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDots : MonoBehaviour
{
    [SerializeField] float lifetime = 2f;
    [SerializeField] Animator dotAnimator;
    private bool onBeatSpot = false;
    [SerializeField] GameObject text;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void Update()
    {
        BlueDotIsClicked();
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
            ScoringSystem.theScore -= 1;
            Destroy(this.gameObject, 2f);
        }
        if (collision.tag == "DotDestroyerLarge")
        {
            dotAnimator.SetTrigger("DotDeath");
            Destroy(this.gameObject, 4f);
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

    public void BlueDotIsClicked()
    {
        Debug.Log("Täällä ollaan!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("BlueDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("BlueDot"))
            {
                ScoringSystem.theScore += 1;
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

            }
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
                ScoringSystem.theScore += 1;
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
                ScoringSystem.theScore += 1;
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
                ScoringSystem.theScore += 1;
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
                ScoringSystem.theScore += 1;
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

            }
        }
    }
}
