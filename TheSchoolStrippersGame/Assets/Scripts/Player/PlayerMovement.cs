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

    private void Start()
    {
        
        underwaterDots = FindObjectOfType<UnderwaterDots>();
        underwaterDotSpawner = FindObjectOfType<UnderwaterDotSpawner>();
        //underwaterDotSpawner.SpawnUnderwaterObjects();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
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
        

    }


    private void SetTargetPosition()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if(hit2D.collider.CompareTag("PlayArea")|| hit2D.collider.CompareTag("BlueDot") || hit2D.collider.CompareTag("RedDot") || hit2D.collider.CompareTag("YellowDot") || hit2D.collider.CompareTag("GreenDot"))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                isMoving = true;
            }
            
            
        //}
        
    }

    private void MovePlayer()
    {
        Player.MovePosition(targetPosition);

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
