using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDots : MonoBehaviour
{
    public float lifetime = 2f;
    [SerializeField] Animator dotAnimator;
    private bool onBeatSpot = false;
    [SerializeField] GameObject deathParticleFX;
    [SerializeField] GameObject[] correctParticleFX;
    bool canDestroyAllDots = false;
    public LayerMask underwaterdotLayer;

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

}
