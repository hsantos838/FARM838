using UnityEngine;

public class ToolTarget : MonoBehaviour
{
    public int health = 10;
    public GameObject dropPrefab; // Prefab a ser dropado na cena
    public Sprite cutSprite; // Sprite a ser exibido após a "morte"
    private bool isCut = false; // Para verificar se o objeto já foi cortado
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Axe") || collision.CompareTag("Pickaxe") || collision.CompareTag("Shovel")) && !isCut)
        {
            animator.SetTrigger("OnHit");
            TakeDamage(1); // A ferramenta causa 1 de dano
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isCut)
        {
            Cut();
        }
    }

    private void Cut()
    {
        isCut = true;
        animator.SetTrigger("TreeCut");
        GetComponent<SpriteRenderer>().sprite = cutSprite;

        // Drop uma quantidade aleatória de prefabs na cena
        int dropCount = Random.Range(1, 5); // Gera um número aleatório entre 1 e 4
        for (int i = 0; i < dropCount; i++)
        {
            if (dropPrefab != null)
            {
                Instantiate(dropPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}