using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 5.8f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private SpriteRenderer sprite;

    public bool isRunning;  
    public bool isPlanting;
    public bool isWatering;
    public bool isFishing;
    public bool isReaping;
    public bool isUsingTool;

    void Start()
    {
        currentSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
  
    void Update()
    {
        HandleActionInput();
        // Captura a entrada do jogador
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (isUsingTool)
        {
            moveVelocity = Vector2.zero; // Parar o movimento se o jogador estiver usando uma ferramenta
        }
        else
        {
            moveInput = new Vector2(moveX, moveY).normalized * currentSpeed;
            moveVelocity = moveInput;

            // Virar o sprite do personagem
            if (moveX < 0)
            {
                sprite.flipX = true;
            }
            else if (moveX > 0)
            {
                sprite.flipX = false;
            }
        }

        // Detectar outras ações do jogador
        isPlanting = Input.GetKeyDown(KeyCode.Alpha1);
        isWatering = Input.GetKeyDown(KeyCode.Alpha2);
        isFishing = Input.GetKeyDown(KeyCode.Alpha3);
        isReaping = Input.GetKeyDown(KeyCode.Alpha4); 
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveVelocity;
    }

    private void HandleActionInput()
    {
        isUsingTool = Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
                      Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4);
    }       
}