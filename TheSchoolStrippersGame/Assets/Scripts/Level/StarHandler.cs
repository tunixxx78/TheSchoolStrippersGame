using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (ScoringSystem.theScore >= 100)
        {
            GetComponent<LevelSelection>().stars[1].SetActive(true);
        }

        if (ScoringSystem.theScore >= 1000)
        {
            GetComponent<LevelSelection>().stars[2].SetActive(true);
        }

        if (ScoringSystem.theScore >= 10000)
        {
            GetComponent<LevelSelection>().stars[3].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
