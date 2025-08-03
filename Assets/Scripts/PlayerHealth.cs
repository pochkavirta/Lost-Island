using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Player Health: " + health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
