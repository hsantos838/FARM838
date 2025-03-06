using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public Sprite[] growthStages;
    public float timeBetweenStages = 5f; // Tempo entre os estágios de crescimento
    private int currentStage = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(Grow), timeBetweenStages, timeBetweenStages);
    }

    void Grow()
    {
        if (currentStage < growthStages.Length - 1)
        {
            currentStage++;
            spriteRenderer.sprite = growthStages[currentStage];
        }
        else
        {
            CancelInvoke(nameof(Grow));
        }
    }

    public bool IsFullyGrown()
    {
        return currentStage == growthStages.Length - 1;
    }
}