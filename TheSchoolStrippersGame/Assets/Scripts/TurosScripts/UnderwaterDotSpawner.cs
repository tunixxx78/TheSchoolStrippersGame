using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterDotSpawner : MonoBehaviour
{
    [SerializeField] int numberToSpawn;
    [SerializeField] List<GameObject> spawnPool;
    [SerializeField] GameObject quad;
    [SerializeField] float spawnRate = 10f;
    bool canSpawn = true;
    bool hasCollected = false;
    public UnderwaterDots underwaterDots;


    private void Start()
    {
        underwaterDots = FindObjectOfType<UnderwaterDots>();
        //StartCoroutine(SpawnAllUnderwaterObjects());
        //SpawnUnderwaterObjects();
    }

    private void Update()
    {
        if(canSpawn == true)
        {
            StartCoroutine(SpawnAllUnderwaterObjects());
        }
    }

    /*public void SpawnUnderwaterObjects()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;

        Vector2 pos;

        for (int i = 0; i < spawnPool.Count; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(spawnPool[i], pos, Quaternion.identity);
        }
         
    }*/


    /*public IEnumerator SpawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;

        Vector2 pos;

        for (int i = 0; i < spawnPool.Count; i++)
        //for(int i = 0; i < numberToSpawn; i++)
        {
            //randomItem = Random.Range(0, spawnPool.Count);
            //toSpawn = spawnPool[randomItem];
            
            

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(spawnPool[i], pos, Quaternion.identity);
            //Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            canSpawn = false;
        }
        yield return new WaitForSeconds(spawnRate);
       
        canSpawn = true;
    }*/

    public IEnumerator SpawnAllUnderwaterObjects()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;

        Vector2 pos;

        for (int i = 0; i < spawnPool.Count; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(spawnPool[i], pos, Quaternion.identity);
            canSpawn = false;
        }

        yield return new WaitForSeconds(7);

        canSpawn = true;
    }
}
