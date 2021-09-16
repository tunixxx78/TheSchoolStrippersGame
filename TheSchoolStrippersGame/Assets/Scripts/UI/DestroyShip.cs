using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    [SerializeField]
    private GameObject fullHealthShip;
    [SerializeField]
    private GameObject damagedShip;
    [SerializeField]
    private GameObject badlyDamagedShip;
    [SerializeField]
    private GameObject reallyBadlyDamagedShip;
    [SerializeField]
    private GameObject destroyedShip;

    [SerializeField]
    private GameObject shipDamageParticle;
    [SerializeField]
    private GameObject[] shields;

    [SerializeField]
    private Transform ParticleSpawnPosition;

    void ChangeSpritetoWrecked()
    {
        Destroy(fullHealthShip);
        damagedShip.gameObject.SetActive(true);

        launchShield(0);
        SpawnParticles();
    }
    void ChangeSpritetoWrecked1()
    {
        Destroy(damagedShip);
        badlyDamagedShip.gameObject.SetActive(true);

        launchShield(1);
        SpawnParticles();
    }
    void ChangeSpritetoWrecked2()
    {
        Destroy(badlyDamagedShip);
        reallyBadlyDamagedShip.gameObject.SetActive(true);

        launchShield(2);
        SpawnParticles();
    }

    void ChangeSpritetoDestroyed()
    {
        Destroy(reallyBadlyDamagedShip);
        destroyedShip.gameObject.SetActive(true);

        
        SpawnParticles();
    }



    /* void Update()
     {

         if (Input.GetMouseButtonDown(0) && GameObject.Find("PlayerScore").GetComponent<Combo>().attackCounter == 1)
         {
             ChangeSpritetoWrecked();
         }
         if (Input.GetMouseButtonDown(0) && GameObject.Find("PlayerScore").GetComponent<Combo>().attackCounter == 2)
         {
             ChangeSpritetoWrecked1();
         }
         if (Input.GetMouseButtonDown(0) && GameObject.Find("PlayerScore").GetComponent<Combo>().attackCounter == 3)
         {
             ChangeSpritetoWrecked2();
         }

     }*/

    //function called from Combo Script's attack();
    public void DamageShip(int attackCounter)
    {
        // Do different things based on attack Counter int
        switch (attackCounter)
        {
            case 1:
                ChangeSpritetoWrecked();
                break;
            case 2:
                ChangeSpritetoWrecked1();
                break;
            case 3:
                ChangeSpritetoWrecked2();
                break;
            case 4:
                ChangeSpritetoDestroyed();
                break;
            default:
                break;
        }
       
    }

    void SpawnParticles()
    {
        GameObject fx = Instantiate(shipDamageParticle, ParticleSpawnPosition.position, Quaternion.identity);

        Destroy(fx, 3);
    }


    void launchShield(int shieldn)
    {
        if (shields[shieldn])
        {
            shields[shieldn].GetComponent<ShieldScript>().ActivateShield();
        }
        
    }
}
