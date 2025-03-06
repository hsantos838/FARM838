using UnityEngine;

public class ToolAction : MonoBehaviour
{
    private ToolController toolController;
    public bool isUsingTool;

    void Start()
    {
        toolController = GetComponent<ToolController>();

        if (toolController == null)
        {
            Debug.LogError("ToolController component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Verifica se o jogador está pressionando o botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            isUsingTool = true;
            PerformToolAction();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isUsingTool = false;
            StopToolAction();
        }

        // Atualizar o estado de uso da ferramenta no PlayerController
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.isUsingTool = isUsingTool;
        }
    }

    void PerformToolAction()
    {
        if (toolController == null)
        {
            return;
        }

        switch (toolController.GetCurrentTool())
        {
            case ToolController.ToolType.Axe:
                // Ação do machado
                Debug.Log("Using Axe to cut trees");
                // Adicione a lógica para cortar árvores aqui
                break;

            case ToolController.ToolType.Shovel:
                // Ação da pá
                Debug.Log("Using Shovel to dig holes");
                // Adicione a lógica para cavar buracos aqui
                break;

            case ToolController.ToolType.Pickaxe:
                // Ação da picareta
                Debug.Log("Using Pickaxe to break stones");
                // Adicione a lógica para quebrar pedras aqui
                break;

            case ToolController.ToolType.None:
                Debug.Log("No tool selected");
                break;
        }
    }

    void StopToolAction()
    {
        // Parar a ação da ferramenta
        Debug.Log("Stopped using tool");
    }
}