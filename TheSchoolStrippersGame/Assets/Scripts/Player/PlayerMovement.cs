using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Player;
    [SerializeField] float speed = 5f, paralysedTime = 1f, paralysedSpeed = 0f, normalSpeed = 5f;
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
    [SerializeField]
    GameObject mermaidObject;

    SFXManager soundManager;

    public bool canMove = true;
    //public LayerMask obstacle, ignore, ignoreThis, ignoreThisToo;
    [SerializeField] GameObject startPoint;

    private void Awake()
    {
        soundManager = FindObjectOfType<SFXManager>();
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void Start()
    {
        //canMove = true;
        underwaterDots = FindObjectOfType<UnderwaterDots>();
        underwaterDotSpawner = FindObjectOfType<UnderwaterDotSpawner>();
        //underwaterDotSpawner.SpawnUnderwaterObjects();

        
    }
    private void Update()
    {

        //PathIsClear();
        /*if (Input.GetMouseButtonDown(0))
        {
                SetTargetPosition();   
        }*/

        
        /*if (hasHitObstacle)
        {
            StartCoroutine(SlowDownPlayer());
        }*/

        if (Input.GetMouseButtonDown(0) && !hasHitObstacle)
        {
            PathIsClear();
            if(canMove == true)
            {
                SetTargetPosition();

                GameObject expandingFX = Instantiate(expandingBubbleFx, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)), Quaternion.identity);
                Destroy(expandingFX, 1);
            }
            

            
        }

        //float x = transform.position.x;
        
        
        //Debug.Log(x);
          

    }

    private void FixedUpdate()
    {
        if (isMoving && canMove == true)
        {
            MovePlayer();
        }
    }

    private void SetTargetPosition()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        Vector3 CharacterScale = transform.localScale;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if (hit2D)
        {
            if (hit2D.collider.CompareTag("PlayArea") || hit2D.collider.CompareTag("BlueDotU") || hit2D.collider.CompareTag("RedDotU") || hit2D.collider.CompareTag("YellowDotU") || hit2D.collider.CompareTag("GreenDotU") && !hasHitObstacle)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (transform.localPosition.x > targetPosition.x)
                {
                    Player.transform.localScale = new Vector3(-1, 1, 1);
                    isMoving = true;
                }

                else
                {
                    Player.transform.localScale = new Vector3(1, 1, 1);
                    isMoving = true;
                }
            }
        }

       
        
    }

    private void MovePlayer()
    {
        
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            soundManager.Swim();

            if (Player.position == targetPosition)
            {
                isMoving = false;

            }
        
        
            
        
        
        //Player.MovePosition(targetPosition);

        
    }

    
    //called from moving obstacle script
    public void SlowdownPlayerFromOtherScript()
    {
        hasHitObstacle = true;
        StartCoroutine(SlowDownPlayer());
        //Spawn StunFX
        Instantiate(PlayerStunFX, this.transform.position, Quaternion.identity);
        
        speed = paralysedSpeed;

    }

    public IEnumerator SlowDownPlayer()
    {
        isMoving = false;
        Player.constraints = RigidbodyConstraints2D.FreezeAll;
        targetPosition = Player.position;
        
        mermaidAnimator.SetTrigger("Stun");
        yield return new WaitForSeconds(paralysedTime);

        Player.constraints = RigidbodyConstraints2D.None;
        speed = normalSpeed;
        isMoving = false;
        hasHitObstacle = false;

    }

    public bool PathIsClear()
    {
        
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D clearPath = Physics2D.Linecast(startPoint.transform.position, targetPosition, 1 << LayerMask.NameToLayer("Obstacle"));
        Debug.DrawLine(startPoint.transform.position, targetPosition, Color.red);
        //Debug.Log(clearPath.collider.tag);

        if(clearPath.collider != null)
        {
            if (clearPath.collider.gameObject.CompareTag("Obstacle"))
            {
                canMove = false;
                Debug.Log("ESTE TIELLÄ");
                isMoving = true;
               
            }
            
        }
        else
        {
            canMove = true;
            isMoving = false;
            
        }

        return canMove;
        
        
    }
    
}
