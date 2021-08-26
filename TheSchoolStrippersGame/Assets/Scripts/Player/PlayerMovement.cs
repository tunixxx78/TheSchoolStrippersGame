using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Player;
    [SerializeField] float speed = 5f;
    Vector3 targetPosition;
    bool isMoving = false;
    [SerializeField] GameObject reSpawnPoint;

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
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;


        isMoving = true;
    }

    private void MovePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Player.transform.position = reSpawnPoint.transform.position;
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BlueDot"))
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
    }
}
