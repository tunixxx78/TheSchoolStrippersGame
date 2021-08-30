using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject dot;

    private void Start()
    {
        var spawn = Instantiate(dot, transform.position, Quaternion.identity);
        spawn.transform.parent = GameObject.Find("Spawn1").transform;
    }
}
