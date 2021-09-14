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
    private GameObject destroyedShip;

    void ChangeSpritetoWrecked()
    {
        Destroy(fullHealthShip);
        damagedShip.gameObject.SetActive(true);
    }
    void ChangeSpritetoWrecked1()
    {
        Destroy(damagedShip);
        badlyDamagedShip.gameObject.SetActive(true);
    }
    void ChangeSpritetoWrecked2()
    {
        Destroy(badlyDamagedShip);
        destroyedShip.gameObject.SetActive(true);
    }

    void Update()
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
    }
}
