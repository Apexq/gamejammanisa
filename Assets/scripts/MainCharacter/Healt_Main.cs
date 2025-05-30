using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt_Main : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Test için: H tuşuna basıldığında hasar al
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1); // 1 hasar al
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage taken! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Character is dead!");
        gameObject.SetActive(false);
    }
}
