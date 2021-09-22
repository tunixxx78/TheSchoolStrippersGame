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
    public UnderwaterDots underwaterDots;
    public UnderwaterDotSpawner underwaterDotSpawner;
    public int scoreAmount = 1;

    

    private void Start()
    {
        
        dotSpawner = FindObjectOfType<DotSpawner>();
        dotAnimator.speed = (dotAnimator.speed / 2f) * dotSpawner.beatTempoForLevel;
        playerMovement = FindObjectOfType<PlayerMovement>();
        combo = FindObjectOfType<Combo>();
        underwaterDots = FindObjectOfType<UnderwaterDots>();
        underwaterDotSpawner = FindObjectOfType<UnderwaterDotSpawner>();
    }

    private void Update()
    {

        transform.position -= new Vector3(dotSpawner.beatTempoForLevel * Time.deltaTime, 0f, 0f);
        //transform.Translate(Vector2.right * -dotSpawner.beatTempoForLevel * Time.deltaTime);

        if (playerMovement.hasHitObstacle == false)
        {
            BlueDotIsClicked();
            RedDotIsClicked();
            GreenDotIsClicked();
            YellowDotIsClicked();
        }
        if (ScoringSystem.theScore == 0)
        {
            ScoreCanNotBeRedused();
        }
        if (ScoringSystem.theScore > 0)
        {
            scoreCanBeReduced = true;
        }
    }

    void DestroyEverything()
    {
        FindObjectOfType<UnderwaterDots>().DestroyAllDots();
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

            Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
            Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
            Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
            Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));


            underwaterDotSpawner.SpawnUnderwaterObjectsNow();

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
        //Debug.Log("SININEN!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("BlueDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("BlueDotU"))
            {
                ScoringSystem.theScore += scoreAmount;
                FindObjectOfType<SFXManager>().CollectingOne();
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
                Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
                Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
                Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));

                underwaterDotSpawner.SpawnUnderwaterObjectsNow();

                // tässä combobar
                combo.ComboBar();

                
            }
            
        }
        else if (Input.GetMouseButtonDown(0) && onBeatSpot == false && CompareTag("BlueDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            
            if (hit2D.collider.CompareTag("BlueDotU"))
            {
                //Particle effect ->
                underwaterDots.WrongDotBlue();
                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
                
            }
            
            
        }
        
        
    }

    public void RedDotIsClicked()
    {
        //Debug.Log("PUNAINEN!");
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("RedDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("RedDotU"))
            {
                ScoringSystem.theScore += scoreAmount;
                FindObjectOfType<SFXManager>().CollectingOne();
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
                Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
                Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
                Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));

                underwaterDotSpawner.SpawnUnderwaterObjectsNow();

                // tässä combobar
                combo.ComboBar();

                
            }
        }

        else if (Input.GetMouseButtonDown(0) && onBeatSpot == false &&  CompareTag("RedDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("RedDotU"))
            {
                //Particle effect ->
                underwaterDots.WrongDotRed();
                Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
                
            }
            

        }
        
    }

    public void GreenDotIsClicked()
    {
        //Debug.Log("VIHREÄ!");
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("GreenDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("GreenDotU"))
            {
                ScoringSystem.theScore += scoreAmount;
                FindObjectOfType<SFXManager>().CollectingOne();
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
                Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
                Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
                Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));

                underwaterDotSpawner.SpawnUnderwaterObjectsNow();

                // tässä combobar
                combo.ComboBar();

                
            }
        }
        else if (Input.GetMouseButtonDown(0) && onBeatSpot == false && CompareTag("GreenDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("GreenDotU"))
            {
                //Particle effect ->
                underwaterDots.WrongDotGreen();
                Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));
                
            }
            

        }
        
    }

    public void YellowDotIsClicked()
    {
        //Debug.Log("KELTAINEN!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("YellowDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("YellowDotU"))
            {
                ScoringSystem.theScore += scoreAmount;
                FindObjectOfType<SFXManager>().CollectingOne();
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
                Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
                Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
                Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));

                underwaterDotSpawner.SpawnUnderwaterObjectsNow();

                // tässä combobar
                combo.ComboBar();

                
            }
        }

        else if (Input.GetMouseButtonDown(0) && onBeatSpot == false && CompareTag("YellowDot"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("YellowDotU"))
            {
                //Particle effect ->
                underwaterDots.WrongDotYellow();
                Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
                
            }
            

        }
        
    }
}
