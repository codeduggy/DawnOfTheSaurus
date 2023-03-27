using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 3; // Bossens liv

    // När bossen träffas av något, t.ex. en spelares skott, anropas denna funktion
    public void TakeDamage(int damage)
    {
        // Minska hälsan med skadan som gjordes
        health -= damage;

        // Kontrollera om bossen har dött
        if (health <= 0)
        {
            Die();
        }
    }

    // När bossen dör anropas denna funktion
    private void Die()
    {
        // Gör något när bossen dör, t.ex. spela upp en dödsanimation eller ljud
        Destroy(gameObject);
    }
}
