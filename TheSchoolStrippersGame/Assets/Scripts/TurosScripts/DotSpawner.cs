using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] dots;
    private float timeBtwSpawns;
    [SerializeField] private float startTimeBtwSpawns, decrreaseTime, minTime = 0.65f;

    private void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, dots.Length);

            var dot = Instantiate(dots[rand], transform.position, Quaternion.identity);
            dot.transform.parent = GameObject.Find("Spawn").transform;
            timeBtwSpawns = startTimeBtwSpawns;

            if(startTimeBtwSpawns > minTime)
            {
                startTimeBtwSpawns -= decrreaseTime;
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
