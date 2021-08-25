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

    private void Start()
    {
        //StartCoroutine(SpawnObjects());
    }

    private void Update()
    {
        if(canSpawn == true)
        {
            StartCoroutine(SpawnObjects());
        }
    }


    public IEnumerator SpawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;

        Vector2 pos;

        for(int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

            canSpawn = false;
        }
        yield return new WaitForSeconds(spawnRate);

        canSpawn = true;
    }
}
