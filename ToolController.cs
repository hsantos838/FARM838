using UnityEngine;

public class ToolController : MonoBehaviour
{
    public enum ToolType { None, Axe, Shovel, Pickaxe, WateringCan, Fertilizer }
    public ToolType currentTool = ToolType.None;

    public GameObject axeTool;
    public GameObject shovelTool;
    public GameObject pickaxeTool;
    public GameObject wateringCanTool;
    public GameObject fertilizerTool;

    void Update()
    {
        // Check which key was pressed to select the tool
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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectTool(ToolType.WateringCan);
            Debug.Log("Watering Can selected");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectTool(ToolType.Fertilizer);
            Debug.Log("Fertilizer selected");
        }
    }

    void SelectTool(ToolType toolType)
    {
        currentTool = toolType;
        axeTool.SetActive(toolType == ToolType.Axe);
        shovelTool.SetActive(toolType == ToolType.Shovel);
        pickaxeTool.SetActive(toolType == ToolType.Pickaxe);
        wateringCanTool.SetActive(toolType == ToolType.WateringCan);
        fertilizerTool.SetActive(toolType == ToolType.Fertilizer);
    }

    public ToolType GetCurrentTool()
    {
        return currentTool;
    }
}