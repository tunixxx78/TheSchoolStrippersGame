using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDots : MonoBehaviour
{
    
    [SerializeField] Animator dotAnimator;
    public bool onBeatSpot = false;
    public bool onBeatSpotTwo = false;
    [SerializeField] GameObject text;
    DotSpawner dotSpawner;
    public PlayerMovement playerMovement;
    private bool playerIsParalized;
    public Combo combo;
    private bool scoreCanBeReduced = true;
    public UnderwaterDots underwaterDots;
    public UnderwaterDotSpawner underwaterDotSpawner;
    public int scoreAmount = 1, scoreMultiplierOne = 2, scoreMultiplierTwo = 3, scoreMultiplierThree = 4;
    public int multiplierOne = 5;
    public int multiplierTwo = 10;
    public int multiplierThree = 20;
    public ScoringSystem scoringSystem;

    public LayerMask underwaterdotLayer;

    

    private void Start()
    {
        
        dotSpawner = FindObjectOfType<DotSpawner>();
        dotAnimator.speed = (dotAnimator.speed / 2f) * dotSpawner.beatTempoForLevel;
        playerMovement = FindObjectOfType<PlayerMovement>();
        combo = FindObjectOfType<Combo>();
        underwaterDots = FindObjectOfType<UnderwaterDots>();
        underwaterDotSpawner = FindObjectOfType<UnderwaterDotSpawner>();
        scoringSystem = FindObjectOfType<ScoringSystem>();
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
        if (collision.tag == "BeatSpot")
        {
            onBeatSpot = true;

        }
        if(collision.tag == "BeatSpotTwo")
        {
            onBeatSpotTwo = true;
        }

        if (collision.CompareTag("DotDestroyer"))
        {
            
            dotAnimator.SetTrigger("DotDeath");

            if(scoreCanBeReduced == true)
            {
                //ScoringSystem.theScore -= 1;
                ScoringSystem.theMultiplierPoints = 0;
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

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BeatSpot")
        {
            onBeatSpot = false;
        }
        if (collision.tag == "BeatSpotTwo")
        {
            onBeatSpotTwo = false;
        }
    }

    public void BlueDotIsClicked()
    {
        //Debug.Log("SININEN!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("BlueDot") && playerMovement.canMove == true)
        {
            //correct dot was clicked
            DotIsClicked("BlueDotU");
            
        }
        else if (Input.GetMouseButtonDown(0) && onBeatSpotTwo == true)
        {
            RaycastHit2D hit2D = ShootRay();
            if (hit2D)
            {
                if (hit2D.collider.CompareTag("BlueDotU"))
                {
                    //Particle effect ->
                    underwaterDots.destroyDotFX(hit2D.collider.gameObject.transform.position);
                    Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));

                }
            }
        }
        
        
        
        
    }

    public void RedDotIsClicked()
    {
        //Debug.Log("PUNAINEN!");
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("RedDot") && playerMovement.canMove == true)
        {
            
            DotIsClicked("RedDotU");
        }

        else if (Input.GetMouseButtonDown(0) && onBeatSpotTwo == true)
        {
            RaycastHit2D hit2D = ShootRay();

            if (hit2D)
            {
                if (hit2D.collider.CompareTag("RedDotU"))
                {
                    //Particle effect ->
                    underwaterDots.destroyDotFX(hit2D.collider.gameObject.transform.position);
                    Destroy(GameObject.FindGameObjectWithTag("RedDotU"));

                }
            }


        }

    }

    public void GreenDotIsClicked()
    {
        //Debug.Log("VIHREÄ!");
        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("GreenDot") && playerMovement.canMove == true)
        {
            
            DotIsClicked("GreenDotU");
        }
        else if (Input.GetMouseButtonDown(0) && onBeatSpotTwo == true)
        {
            RaycastHit2D hit2D = ShootRay();

            if (hit2D)
            {
                if (hit2D.collider.CompareTag("GreenDotU"))
                {
                    //Particle effect ->
                    underwaterDots.destroyDotFX(hit2D.collider.gameObject.transform.position);
                    Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));

                }
            }


        }
      

    }

    public void YellowDotIsClicked()
    {
        //Debug.Log("KELTAINEN!");

        if (Input.GetMouseButtonDown(0) && onBeatSpot == true && CompareTag("YellowDot") && playerMovement.canMove == true)
        {

            DotIsClicked("YellowDotU");
        }

        else if (Input.GetMouseButtonDown(0) && onBeatSpotTwo == true)
        {
            RaycastHit2D hit2D = ShootRay();

            if (hit2D)
            {
                if (hit2D.collider.CompareTag("YellowDotU"))
                {
                    //Particle effect ->
                    underwaterDots.destroyDotFX(hit2D.collider.gameObject.transform.position);
                    Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));

                }
            }
            

        }


    }

    void WrongDotsClicked()
    { 
            RaycastHit2D hit2D = ShootRay();
            if (hit2D)
            {
            if (hit2D.collider.CompareTag("BlueDotU"))
            {
                underwaterDots.destroyDotFX(hit2D.collider.gameObject.transform.position);
                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));

            }
            }
    }

    //this happens when correct dot has been clicked
    void DotIsClicked(string dotTag)
    {


        RaycastHit2D hit2D = ShootRay();

        if (hit2D)
        {
            if (hit2D.collider.CompareTag(dotTag))
            {
                if(ScoringSystem.theMultiplierPoints <= multiplierOne)
                {
                    ScoringSystem.theScore += scoreAmount;
                    ScoringSystem.thePoints += scoreAmount;
                    ScoringSystem.theMultiplierPoints += scoreAmount;
                }
                if(ScoringSystem.theMultiplierPoints >= multiplierOne && ScoringSystem.theMultiplierPoints <= multiplierTwo)
                {
                    ScoringSystem.theScore += scoreAmount * scoreMultiplierOne;
                    ScoringSystem.thePoints += scoreAmount * scoreMultiplierOne;
                    ScoringSystem.theMultiplierPoints += scoreAmount;
                }
                if(ScoringSystem.theMultiplierPoints >= multiplierTwo && ScoringSystem.theMultiplierPoints <= multiplierThree)
                {
                    ScoringSystem.theScore += scoreAmount * scoreMultiplierTwo;
                    ScoringSystem.thePoints += scoreAmount * scoreMultiplierTwo;
                    ScoringSystem.theMultiplierPoints += scoreAmount;
                }
                if(ScoringSystem.theMultiplierPoints >= multiplierThree)
                {
                    ScoringSystem.theScore += scoreAmount * scoreMultiplierThree;
                    ScoringSystem.thePoints += scoreAmount * scoreMultiplierThree;
                    ScoringSystem.theMultiplierPoints += scoreAmount;
                }
                
                FindObjectOfType<SFXManager>().CollectingOne();
                Destroy(this.gameObject, 0.1f);
                Instantiate(text, transform.position, Quaternion.identity);

                Destroy(GameObject.FindGameObjectWithTag("BlueDotU"));
                Destroy(GameObject.FindGameObjectWithTag("RedDotU"));
                Destroy(GameObject.FindGameObjectWithTag("YellowDotU"));
                Destroy(GameObject.FindGameObjectWithTag("GreenDotU"));

                if (ScoringSystem.thePoints >= scoringSystem.pointBarrier)
                {
                    FindObjectOfType<ScoringSystem>().PowerUpSpawn();
                }
               
                underwaterDotSpawner.SpawnUnderwaterObjectsNow();

                // tässä combobar
                combo.ComboBar();
                //spawn FX for correct dot
                underwaterDots.spawnFX(hit2D.collider.gameObject.transform.position, 0);


            }
        }

        
    }

    RaycastHit2D ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 20, underwaterdotLayer);

        return hit2D;
        
    }

    
}
