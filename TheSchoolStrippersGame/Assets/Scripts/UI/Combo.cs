using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combo : MonoBehaviour
{
    public int attackCounter = 0;

    public int maximum;
    public int current;
    public Image mask;
    private void Start()
    {
        mask.fillAmount = 0;
    }
    public void ModifyHealth()
    {
        
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            current++;
            ModifyHealth();
        }

        if (current >= 3)
        {
            Attack();
            current = 0;
            ModifyHealth();
            //current -= 3;
        }
        if (current < 0)
        {
            current = 0;
        }
        Debug.Log(current);
    }

    public void ComboBar()
    {
        if (current < 3)
        {
            current++;
            ModifyHealth();
        }
    }
    public void StartComboBar()
    {
        if (current > 0)
        {
            current--;
            ModifyHealth();
        }
    }

    public void Attack()
    {
        GameObject.Find("attack").GetComponent<Animator>().SetBool("attack", true);
        StartCoroutine(BoolToFalse());
        attackCounter += 1;
        StartCoroutine(WinGame());
    }

    public IEnumerator BoolToFalse()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("attack").GetComponent<Animator>().SetBool("attack", false);
    }

    public IEnumerator WinGame()
    {
        if(attackCounter == 4)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("WinScene");
        }
    }

}
