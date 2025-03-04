using UnityEngine;

public class Tool : MonoBehaviour
{
    protected BoxCollider2D toolCollider;
    protected PlayerAnimationController animator;
    protected SpriteRenderer playerSpriteRenderer;

    private Vector2 originalOffset;

    void Start()
    {
        toolCollider = GetComponent<BoxCollider2D>();
        animator = GetComponentInParent<PlayerAnimationController>();
        playerSpriteRenderer = GetComponentInParent<SpriteRenderer>();

        if (toolCollider == null)
        {
            Debug.LogError("BoxCollider2D component not found on tool.");
        }

        if (animator == null)
        {
            Debug.LogError("PlayerAnimationController component not found on player.");
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
}