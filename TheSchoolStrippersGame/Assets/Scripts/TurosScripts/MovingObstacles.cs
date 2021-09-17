using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    [SerializeField] float speed = 2f, speedSlow = 1f;
    [SerializeField] float speedBurstDuration = 1f, normalSpeedDuration = 1f;
    bool isSwimmingFast = true;
    bool isSimmingSlow = false;

    private void Update()
    {
        if (isSwimmingFast)
        {
            StartCoroutine(SwimmingFast());
            //transform.Translate(Vector2.right * -speed * Time.deltaTime);
        }

        if(isSimmingSlow && isSwimmingFast == false)
        {
            StartCoroutine(SwimmingSlow());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DotDestroyer"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("ObstacleDestroyer"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            Debug.Log("OSUTTU PELAAJAAN!");
            FindObjectOfType<PlayerMovement>().SlowdownPlayerFromOtherScript();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ObstacleDestroyer")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SwimmingFast()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        yield return new WaitForSeconds(speedBurstDuration);

        isSwimmingFast = false;
        isSimmingSlow = true;

    }

    IEnumerator SwimmingSlow()
    {
        transform.Translate(Vector2.right * -speedSlow * Time.deltaTime);

        yield return new WaitForSeconds(normalSpeedDuration);

        isSimmingSlow = false;
        isSwimmingFast = true;
        
    }
}
