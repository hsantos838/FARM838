using UnityEngine;

public class Plant : MonoBehaviour
{
    public Sprite[] growthStages;
    public float timeToGrow = 5f;
    private int currentStage = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToGrow && currentStage < growthStages.Length - 1)
        {
            timer = 0f;
            currentStage++;
            GetComponent<SpriteRenderer>().sprite = growthStages[currentStage];
        }
    }

    public bool IsFullyGrown()
    {
        return currentStage == growthStages.Length - 1;
    }

    public void Harvest()
    {
        if (IsFullyGrown())
        {
            // Implement harvest logic, e.g., adding to inventory
            Destroy(gameObject);
        }
    }
}