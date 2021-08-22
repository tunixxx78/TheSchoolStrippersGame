using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject dot;

    private void Start()
    {
        Instantiate(dot, transform.position, Quaternion.identity);
    }
}
