using UnityEngine;

public class ToolController : MonoBehaviour
{
    public enum ToolType { None, Axe, Shovel, Pickaxe }
    public ToolType currentTool = ToolType.None;

    public GameObject axeTool;
    public GameObject shovelTool;
    public GameObject pickaxeTool;

    void Update()
    {
        // Verifica qual tecla foi pressionada para selecionar a ferramenta
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectTool(ToolType.Axe);
            Debug.Log("Axe selected");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectTool(ToolType.Shovel);
            Debug.Log("Shovel selected");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectTool(ToolType.Pickaxe);
            Debug.Log("Pickaxe selected");
        }
    }

    void SelectTool(ToolType toolType)
    {
        currentTool = toolType;
        axeTool.SetActive(toolType == ToolType.Axe);
        shovelTool.SetActive(toolType == ToolType.Shovel);
        pickaxeTool.SetActive(toolType == ToolType.Pickaxe);
    }

    public ToolType GetCurrentTool()
    {
        return currentTool;
    }
}