using UnityEngine;

public class AxeTool : MonoBehaviour
{
    private BoxCollider2D toolCollider;
    private Animator animator;
    private SpriteRenderer playerSpriteRenderer;

    private Vector2 originalOffset;

    void Start()
    {
        toolCollider = GetComponent<BoxCollider2D>();
        animator = GetComponentInParent<Animator>();
        playerSpriteRenderer = GetComponentInParent<SpriteRenderer>();

        if (toolCollider == null)
        {
            Debug.LogError("BoxCollider2D component not found on tool.");
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found on player.");
        }

        if (playerSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on player.");
        }

        // Salvar a posição original do offset do colisor
        originalOffset = toolCollider.offset;

        // Inicialmente desativar o colisor da ferramenta
        toolCollider.enabled = false;
    }

    void Update()
    {
        // Inverter a posição do eixo X do colisor com base na direção do jogador
        toolCollider.offset = new Vector2(playerSpriteRenderer.flipX ? -originalOffset.x : originalOffset.x, originalOffset.y);
    }

    // Método chamado pelo Animator via Animation Event
    public void EnableToolCollider()
    {
        toolCollider.enabled = true;
    }

    // Método chamado pelo Animator via Animation Event
    public void DisableToolCollider()
    {
        toolCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            UseTool(collision);
        }
    }

    public void UseTool(Collider2D collision)
    {
        // Aciona a animação da ferramenta
        animator.SetTrigger("UseAxe");

        // Adicione a lógica específica para interagir com objetos com a tag "Tree"
        Debug.Log("Axe used on a tree.");

        // Se a árvore tem um script de saúde, reduza a saúde
        Tree tree = collision.GetComponent<Tree>();
        if (tree != null)
        {
            tree.TakeDamage(1);
        }
    }
}