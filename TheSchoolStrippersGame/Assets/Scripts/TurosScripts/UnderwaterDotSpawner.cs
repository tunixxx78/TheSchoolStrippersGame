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
            //StartCoroutine(SpawnAllUnderwaterObjects());
            SpawnUnderwaterObjectsNow();
        }

        
    }

    

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

            //var spawnPoint = spawnPool[i];
            var spawnPoint = Instantiate(spawnPool[i], pos, Quaternion.identity);
            //spawnPoint.transform.SetParent(GameObject.Find("DotSpawnPoint").transform);
            canSpawn = false;
        }

        yield return new WaitForSeconds(7);

        canSpawn = true;
    }

    public void SpawnUnderwaterObjectsNow()
    {
        
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;

        Vector2 pos = new Vector2(0, 0);

        
            for (int i = 0; i < spawnPool.Count; i++)
            {


                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

                pos = new Vector2(screenX, screenY);

                var spawnPoint = Instantiate(spawnPool[i], pos, Quaternion.identity);

                canSpawn = false;

             }

    }


    
}
