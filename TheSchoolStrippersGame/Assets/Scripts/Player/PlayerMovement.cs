using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Player;
    [SerializeField] float speed = 5f, paralysedTime = 4f;
    Vector2 targetPosition;
    bool isMoving = false;
    public bool hasHitObstacle = false;
    public MovingDots movingDots;
    public UnderwaterDots underwaterDots;
    public UnderwaterDotSpawner underwaterDotSpawner;

    [SerializeField]
    GameObject PlayerStunFX;
    [SerializeField]
    Animator mermaidAnimator;
    [SerializeField]
    GameObject expandingBubbleFx;
    private void Awake()
    {
        
    }

    private void Start()
    {
        
        underwaterDots = FindObjectOfType<UnderwaterDots>();
        underwaterDotSpawner = FindObjectOfType<UnderwaterDotSpawner>();
        //underwaterDotSpawner.SpawnUnderwaterObjects();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
                SetTargetPosition();   
        }

        if (isMoving)
        {
            MovePlayer();
        }
        if (hasHitObstacle)
        {
            StartCoroutine(SlowDownPlayer());
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject expandingFX = Instantiate(expandingBubbleFx, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10)), Quaternion.identity);
            Destroy(expandingFX, 1);
        }

    }


    private void SetTargetPosition()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if(hit2D.collider.CompareTag("PlayArea")|| hit2D.collider.CompareTag("BlueDotU") || hit2D.collider.CompareTag("RedDotU") || hit2D.collider.CompareTag("YellowDotU") || hit2D.collider.CompareTag("GreenDotU"))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                isMoving = true;
            }
            
            
        //}
        
    }

    private void MovePlayer()
    {
        Player.MovePosition(targetPosition);

        FindObjectOfType<SFXManager>().Swim();

        if(Player.position == targetPosition)
        {
            isMoving = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
            if (collision.CompareTag("BlueDot"))
            {
                FindObjectOfType<UnderwaterDots>().BlueDotIsClicked();
            }
            if (collision.CompareTag("RedDot"))
            {
                FindObjectOfType<UnderwaterDots>().RedDotIsClicked();
            }
            if (collision.CompareTag("GreenDot"))
            {
                FindObjectOfType<UnderwaterDots>().GreenDotIsClicked();
            }
            if (collision.CompareTag("YellowDot"))
            {
                FindObjectOfType<UnderwaterDots>().YellowDotIsClicked();
            }
        */
        
        if (collision.CompareTag("Obstacle"))
        {
            hasHitObstacle = true;

            //Spawn StunFX
            Instantiate(PlayerStunFX, this.transform.position, Quaternion.identity);

            mermaidAnimator.SetTrigger("Stun");
            
        }

    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    public IEnumerator SlowDownPlayer()
    {
        Debug.Log("OOOOSUUUUMAAAAA");
        Player.constraints = RigidbodyConstraints2D.FreezeAll;
        
        yield return new WaitForSeconds(paralysedTime);

        Player.constraints = RigidbodyConstraints2D.None;
        hasHitObstacle = false;

    }
    
}
