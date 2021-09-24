using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject dot;
    float lifeSpan = 2f;

    private void Start()
    {
        var spawn = Instantiate(dot, transform.position, Quaternion.identity);
        spawn.transform.parent = GameObject.Find("Spawn1").transform;

        Destroy(this.gameObject, lifeSpan);
    }
}
