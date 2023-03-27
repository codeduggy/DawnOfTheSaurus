using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miaBoss : MonoBehaviour
{
    public int health = 3;
    public GameObject[] projectiles;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
        }
    }

    public void ShootProjectile()
    {
        int index = Random.Range(0, projectiles.Length);
        Instantiate(projectiles[index], transform.position, Quaternion.identity);
    }
}
