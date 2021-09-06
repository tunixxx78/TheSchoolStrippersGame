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
    [SerializeField] GameObject reSpawnPoint;
    public MovingDots movingDots;
    public LayerMask NoGoZone;
    

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

    private void OutOfBounds()
    {

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
