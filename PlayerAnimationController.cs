using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private ToolController toolController;
    private ToolAction toolAction;
    private Vector2 moveInput;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        toolController = GetComponent<ToolController>();
        toolAction = GetComponent<ToolAction>();

        // Verifique se todos os componentes foram inicializados corretamente
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
        if (playerController == null)
        {
            Debug.LogError("PlayerController component not found on " + gameObject.name);
        }
        if (toolController == null)
        {
            Debug.LogError("ToolController component not found on " + gameObject.name);
        }
        if (toolAction == null)
        {
            Debug.LogError("ToolAction component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (animator == null || playerController == null || toolController == null || toolAction == null)
        {
            // Se qualquer um dos componentes não estiver inicializado, não prossiga com a atualização
            return;
        }

        // Captura a entrada do jogador
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        // Atualiza o parâmetro do Animator
        if (playerController.isPlanting)
        {
            animator.SetInteger("Transicao", 3); // Plantando
        }
        else if (playerController.isWatering)
        {
            animator.SetInteger("Transicao", 4); // Regando
        }
        else if (playerController.isFishing)
        {
            animator.SetInteger("Transicao", 5); // Pescando
        }
        else if (playerController.isReaping) // Alterado de isDigging para isReaping
        {
            animator.SetInteger("Transicao", 6); // Ceifando
        }
        else if (playerController.isRunning)
        {
            animator.SetInteger("Transicao", 2); // Correndo
        }
        else if (moveInput.sqrMagnitude > 0)
        {
            animator.SetInteger("Transicao", 1); // Andando
        }
        else
        {
            animator.SetInteger("Transicao", 0); // Idle
        }

        // Atualiza a animação da ferramenta
        if (toolAction.isUsingTool)
        {
            switch (toolController.GetCurrentTool())
            {
                case ToolController.ToolType.Axe:
                    animator.SetInteger("Transicao", 7); // Ação do machado
                    break;

                case ToolController.ToolType.Shovel:
                    animator.SetInteger("Transicao", 8); // Ação da pá
                    break;

                case ToolController.ToolType.Pickaxe:
                    animator.SetInteger("Transicao", 9); // Ação da picareta
                    break;

                default:
                    // Não faça nada, mantenha o estado atual
                    break;
            }
        }
    }

    public void SetAnimationParameter(string parameter, int value)
    {
        animator.SetInteger(parameter, value);
    }
}