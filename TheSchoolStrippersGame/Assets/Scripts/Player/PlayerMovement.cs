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
    [SerializeField] GameObject quad;
    public MovingDots movingDots;
    public UnderwaterDots underwaterDots;
    public UnderwaterDotSpawner underwaterDotSpawner;
    float screenMinX, screenMaxX, screenMinY, screenMaxY;
    Vector2 pos;

    private void Start()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenMinX, screenMaxX, screenMinY, screenMaxY;

        Vector2 pos;

        screenMinX = c.bounds.min.x;
        screenMaxX = c.bounds.max.x;
        screenMinY = c.bounds.min.y;
        screenMaxY = c.bounds.max.y;

        pos = new Vector2(screenMaxX - screenMinX, screenMaxY - screenMinY);

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
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            isMoving = true;
        }
        
    }

    private void MovePlayer()
    {
        Player.MovePosition(targetPosition);

        if(Player.position == targetPosition)
        {
            isMoving = false;
            //Player.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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

        
        if (collision.CompareTag("Obstacle"))
        {
            hasHitObstacle = true; 
        }
        /*if (collision.CompareTag("NoZoneForPlayer"))
        {
            Player.isKinematic = false;
            Player.gravityScale = 1;
        }
        if (collision.CompareTag("BackToWater"))
        {
            Player.isKinematic = true;
            Player.gravityScale = 0;
            //Player.constraints = RigidbodyConstraints2D.FreezePositionY;
        }*/

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
