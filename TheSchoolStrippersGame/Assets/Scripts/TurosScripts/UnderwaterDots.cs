using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDots : MonoBehaviour
{
    public float lifetime = 2f;
    [SerializeField] Animator dotAnimator;
    private bool onBeatSpot = false;
    [SerializeField] GameObject deathParticleFX;
    [SerializeField] GameObject correctParticleFX;
    bool canDestroyAllDots = false;

    private void Start()
    {
        //Destroy(this.gameObject, lifetime);
    }

    private void Update()
    {
        if (canDestroyAllDots == true)
        {
            Destroy(this.gameObject);
        }
        canDestroyAllDots = false;

        if (Input.GetKeyDown(KeyCode.P))
        {
            DestroyAllDots();
        }
    }

    public void DestroyAllDots()
    {
        canDestroyAllDots = true;   
        
    }

    public void WrongDotBlue()
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("BlueDotU"))
            {
                //Here is place for particle effect instantiations
                Instantiate(deathParticleFX, hit2D.collider.gameObject.transform.position, Quaternion.identity);
                
            }

        
    }

    public void WrongDotRed()
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("RedDotU"))
            {
                //Here is place for particle effect instantiations
                Instantiate(deathParticleFX, hit2D.collider.gameObject.transform.position, Quaternion.identity);

            }

        
    }

    public void WrongDotGreen()
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("GreenDotU"))
            {
                //Here is place for particle effect instantiations
                Instantiate(deathParticleFX, hit2D.collider.gameObject.transform.position, Quaternion.identity);

            }

        
    }

    public void WrongDotYellow()
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);


            if (hit2D.collider.CompareTag("YellowDotU"))
            {
                //Here is place for particle effect instantiations
                Instantiate(deathParticleFX, hit2D.collider.gameObject.transform.position, Quaternion.identity);

            }

        
    }

    public void spawnFX(Vector2 position)
    {
        Instantiate(correctParticleFX, position, Quaternion.identity);
    }
}
