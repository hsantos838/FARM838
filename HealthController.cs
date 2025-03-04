using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tool"))
        {
            TakeDamage(10); // Assumindo que a ferramenta causa 10 de dano
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implementar lógica de morte do prefab, como tocar uma animação de destruição
        Destroy(gameObject);
    }
}