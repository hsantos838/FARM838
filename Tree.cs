using UnityEngine;

public class Tree : MonoBehaviour
{
    public int health = 5; // Quantidade de dano que a árvore pode receber antes de ser destruída
    public GameObject dropItem; // O item que será dropado quando a árvore for destruída
    public Transform dropPosition; // A posição onde o item será dropado

    // Método para aplicar dano à árvore
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DropItem();
            Destroy(gameObject); // Destrói a árvore quando a saúde chega a 0
        }
    }

    // Método para dropar o item
    private void DropItem()
    {
        if (dropItem != null && dropPosition != null)
        {
            Instantiate(dropItem, dropPosition.position, Quaternion.identity);
        }
    }
}