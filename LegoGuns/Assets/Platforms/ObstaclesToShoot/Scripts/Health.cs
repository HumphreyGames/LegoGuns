using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("Health Stats")]
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI healthNumberText;

    private void Start()
    {
        currentHealth = maxHealth;
        healthNumberText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        healthNumberText.text = currentHealth.ToString();

        GetComponent<Animator>().SetTrigger("Hit");
    }

    private void Die()
    {
        Destroy(healthNumberText.gameObject);
        Destroy(gameObject);
    }
}
