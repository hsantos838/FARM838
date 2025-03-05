using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 5.8f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private SpriteRenderer spriteRenderer;

    public bool isRunning;
    public bool isPlanting;
    public bool isWatering;
    public bool isFishing;
    public bool isReaping; // Alterado de isDigging para isReaping
    public bool isUsingTool; // Adicionado para verificar se o jogador está usando uma ferramenta

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        // Captura a entrada do jogador
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (!isUsingTool) // Permitir movimento apenas se o jogador não estiver usando uma ferramenta
        {
            moveInput = new Vector2(moveX, moveY).normalized;

            // Detectar se o jogador está correndo
            isRunning = Input.GetKey(KeyCode.LeftShift);

            // Atualizar a velocidade com base no estado de corrida
            currentSpeed = isRunning ? runSpeed : walkSpeed;
            moveVelocity = moveInput * currentSpeed;

            // Virar o sprite do personagem
            if (moveX < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveX > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            moveVelocity = Vector2.zero; // Parar o movimento se o jogador estiver usando uma ferramenta
        }

        // Detectar outras ações do jogador
        isPlanting = Input.GetKeyDown(KeyCode.Alpha1);
        isWatering = Input.GetKeyDown(KeyCode.Alpha2);
        isFishing = Input.GetKeyDown(KeyCode.Alpha3);
        isReaping = Input.GetKeyDown(KeyCode.Alpha4); // Alterado de isDigging para isReaping
    }

    void FixedUpdate()
    {
        // Move o jogador usando física
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
