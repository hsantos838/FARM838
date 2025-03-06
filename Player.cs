using UnityEngine;

public class Player : MonoBehaviour
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
    public bool isReaping;
    public bool isUsingTool;
    public GameObject shovel;
    public GameObject axe;
    public GameObject pickaxe; // Adicione esta linha para o prefab da PickaxeTool
    public GameObject plantPrefab;

    private Soil currentSoil;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        HandleMovementInput();
        HandleActionInput();
        UpdateToolUsage();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandleMovementInput()
    {
        if (!isUsingTool)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(moveX, moveY).normalized;

            isRunning = Input.GetKey(KeyCode.LeftShift);
            currentSpeed = isRunning ? runSpeed : walkSpeed;
            moveVelocity = moveInput * currentSpeed;

            if (moveX != 0)
            {
                spriteRenderer.flipX = moveX < 0;
            }
        }
        else
        {
            moveVelocity = Vector2.zero;
        }
    }

    private void HandleActionInput()
    {
        if (Input.GetMouseButtonDown(0) && currentSoil != null)
        {
            if (shovel.activeInHierarchy)
            {
                if (!currentSoil.isDug)
                {
                    currentSoil.Dig();
                }
                else if (!currentSoil.isPlanted)
                {
                    currentSoil.Plant(plantPrefab);
                }
            }
            // Adicione lógica para o uso do axe aqui
            if (axe.activeInHierarchy)
            {
                // Adicione lógica para usar o axe
            }
            // Adicione lógica para o uso do pickaxe aqui
            if (pickaxe.activeInHierarchy)
            {
                // Adicione lógica para usar o pickaxe
            }
        }

        // Detectar outras ações do jogador
        isPlanting = Input.GetKeyDown(KeyCode.Alpha1);
        isWatering = Input.GetKeyDown(KeyCode.Alpha2);
        isFishing = Input.GetKeyDown(KeyCode.Alpha3);
        isReaping = Input.GetKeyDown(KeyCode.Alpha4);
    }

    private void UpdateToolUsage()
    {
        isUsingTool = isPlanting || isWatering || isFishing || isReaping;
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TerraPlantavel"))
        {
            currentSoil = collision.GetComponent<Soil>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TerraPlantavel"))
        {
            currentSoil = null;
        }
    }
}