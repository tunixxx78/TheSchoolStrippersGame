using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite shipWrecked;
    [SerializeField]
    private Sprite shipWrecked1;
    [SerializeField]
    private Sprite shipWrecked2;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void ChangeSpritetoWrecked()
    {
        spriteRenderer.sprite = shipWrecked;
    }
    void ChangeSpritetoWrecked1()
    {
        spriteRenderer.sprite = shipWrecked1;
    }
    void ChangeSpritetoWrecked2()
    {
        spriteRenderer.sprite = shipWrecked2;
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
