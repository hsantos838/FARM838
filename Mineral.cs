using UnityEngine;

public class Mineral : MonoBehaviour
{
    public int health = 3; // Quantidade de dano que o mineral pode receber antes de ser destruído
    public GameObject dropItem; // O item que será dropado quando o mineral for destruído
    public Transform dropPosition; // A posição onde o item será dropado

    // Método para aplicar dano ao mineral
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DropItem();
            Destroy(gameObject);
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