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

        // Save the original position of the collider offset
        originalOffset = toolCollider.offset;

        // Initially disable the tool collider
        toolCollider.enabled = false;
    }

    void Update()
    {
        // Flip the collider's X position based on the player's direction
        toolCollider.offset = new Vector2(playerSpriteRenderer.flipX ? -originalOffset.x : originalOffset.x, originalOffset.y);
    }

    // Method called by the Animator via Animation Event
    public void EnableToolCollider()
    {
        toolCollider.enabled = true;
    }

    // Method called by the Animator via Animation Event
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
        // Trigger the tool animation
        animator.SetInteger("Transicao", 7); // UseAxe

        // Add specific logic to interact with objects tagged as "Tree"
        Debug.Log("Axe used on a tree.");

        // If the tree has a health script, reduce its health
        Tree tree = collision.GetComponent<Tree>();
        if (tree != null)
        {
            tree.TakeDamage(1);
        }
    }
}