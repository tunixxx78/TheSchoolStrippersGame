using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDots : MonoBehaviour
{
    
    [SerializeField] Animator dotAnimator;
    public bool onBeatSpot = false;
    [SerializeField] GameObject text;
    DotSpawner dotSpawner;
    public PlayerMovement playerMovement;
    private bool playerIsParalized;
    public Combo combo;
    private bool scoreCanBeReduced = true;

    private void Start()
    {
        dotSpawner = FindObjectOfType<DotSpawner>();
        dotAnimator.speed = (dotAnimator.speed / 2f) * dotSpawner.beatTempoForLevel;
        playerMovement = FindObjectOfType<PlayerMovement>();
        combo = FindObjectOfType<Combo>();
        
    }

    private void Update()
    {

        transform.Translate(Vector2.right * -dotSpawner.beatTempoForLevel * Time.deltaTime);

        if (playerMovement.hasHitObstacle == false)
        {
            BlueDotIsClicked();
            RedDotIsClicked();
            GreenDotIsClicked();
            YellowDotIsClicked();
        }
        if (ScoringSystem.theScore <= 0)
        {
            ScoreCanNotBeRedused();
        }
        if (ScoringSystem.theScore >= 0)
        {
            scoreCanBeReduced = true;
        }
    }

    private void ScoreCanNotBeRedused()
    {
        scoreCanBeReduced = false;
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
            if(scoreCanBeReduced == true)
            {
                ScoringSystem.theScore -= 1;
            }
            
            
           
            //GameObject.Find("PlayerScore").GetComponent<Combo>().StartComboBar();
            combo.StartComboBar();
            Destroy(this.gameObject, 2f);
        }
        if (collision.tag == "DotDestroyerLarge")
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

    public void BlueDotIsClicked()
    {
        Debug.Log("SININEN!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("BlueDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("BlueDot"))
            {
                ScoringSystem.theScore += 1;
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

                // tässä combobar
                //GameObject.Find("PlayerScore").GetComponent<Combo>().ComboBar();
                combo.ComboBar();
            }
        }
    }

    public void RedDotIsClicked()
    {
        Debug.Log("PUNAINEN!");
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("RedDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("RedDot"))
            {
                ScoringSystem.theScore += 1;
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                // tässä combobar
                //GameObject.Find("PlayerScore").GetComponent<Combo>().ComboBar();
                combo.ComboBar();
            }
        }
    }

    public void GreenDotIsClicked()
    {
        Debug.Log("VIHREÄ!");
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("GreenDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("GreenDot"))
            {
                ScoringSystem.theScore += 1;
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                // tässä combobar
                //GameObject.Find("PlayerScore").GetComponent<Combo>().ComboBar();
                combo.ComboBar();
            }
        }
    }

    public void YellowDotIsClicked()
    {
        Debug.Log("KELTAINEN!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("YellowDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("YellowDot"))
            {
                ScoringSystem.theScore += 1;
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                // tässä combobar
                //GameObject.Find("PlayerScore").GetComponent<Combo>().ComboBar();
                combo.ComboBar();
            }
        }
    }
}
