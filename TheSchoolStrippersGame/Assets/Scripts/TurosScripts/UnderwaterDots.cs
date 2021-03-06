using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDots : MonoBehaviour
{
    public float lifetime = 2f;
    Animator dotAnimator;
    private bool onBeatSpot = false;
    [SerializeField] GameObject deathParticleFX;
    [SerializeField] GameObject[] correctParticleFX;
    bool canDestroyAllDots = false;
    public LayerMask underwaterdotLayer;

    private void Awake()
    {
        dotAnimator = this.GetComponent<Animator>();
    }
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

    public void spawnFX(Vector2 position, int color)
    {
        Instantiate(correctParticleFX[color], position, Quaternion.identity);
    }

    public void destroyDotFX(Vector2 position)
    {
        Instantiate(deathParticleFX, position, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        dotAnimator.SetBool("Hover", true);
       
    }

    private void OnMouseExit()
    {
        dotAnimator.SetBool("Hover", false);
    }
}
