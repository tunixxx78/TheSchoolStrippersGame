using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject text;

    public void ShowText()
    {
        Instantiate(text, transform.position, Quaternion.identity);
    }
}
