using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combo : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;
    private int currentHealth;
    public event Action<float> OnHealthPctChanged = delegate { };
    private int attackCounter = 0;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-1);
            Debug.Log(currentHealth);
        }

        if(currentHealth <= 0)
        {
            Attack();
            Debug.Log("Attack!!!");
            ModifyHealth(+3);
        }
    }

    public void ComboBar()
    {
        ModifyHealth(-1);
    }
    public void StartComboBar()
    {
        ModifyHealth(+1);
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
