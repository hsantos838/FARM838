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
    public GameObject pickaxe; // Add this line for the PickaxeTool prefab
    public GameObject plantPrefab;
    public GameObject wateringCan;
    public GameObject fertilizer;

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
            // Logic for using the axe
            if (axe.activeInHierarchy)
            {
                // Add logic for using the axe
            }
            // Logic for using the pickaxe
            if (pickaxe.activeInHierarchy)
            {
                // Add logic for using the pickaxe
            }
            // Logic for using the watering can
            if (wateringCan.activeInHierarchy)
            {
                currentSoil.Water();
            }
            // Logic for using the fertilizer
            if (fertilizer.activeInHierarchy)
            {
                currentSoil.Water(); // Fertilizing has the same effect as watering for simplicity
            }
        }

        // Detect other player actions
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