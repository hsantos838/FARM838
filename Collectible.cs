using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        // Adiciona a lógica de coleta aqui, como adicionar ao inventário do jogador
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.CollectItem();
        }

        // Destroi o objeto coletado
        Destroy(gameObject);
    }
}