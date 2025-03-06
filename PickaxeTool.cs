using UnityEngine;

public class PickaxeTool : MonoBehaviour
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
        if (collision.CompareTag("Mineral"))
        {
            UseTool(collision);
        }
    }

    public void UseTool(Collider2D collision)
    {
        // Aciona a animação da ferramenta
        animator.SetTrigger("UsePickaxe");

        // Adicione a lógica específica para interagir com objetos com a tag "Mineral"
        Debug.Log("Pickaxe used on a mineral.");

        // Se o mineral tem um script de saúde, reduza a saúde
        Mineral mineral = collision.GetComponent<Mineral>();
        if (mineral != null)
        {
            mineral.TakeDamage(1);
        }
    }
}