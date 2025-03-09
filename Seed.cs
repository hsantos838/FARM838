using UnityEngine;

public class Seed : MonoBehaviour
{
    public float growthTime;
    public Sprite[] growthStages;
    public GameObject[] drops;

    private int currentStage = 0;
    private float timer = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
        UpdateGrowthStage();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= growthTime)
        {
            timer = 0;
            AdvanceGrowthStage();
        }
    }

    private void AdvanceGrowthStage()
    {
        if (currentStage < growthStages.Length - 1)
        {
            currentStage++;
            UpdateGrowthStage();
        }
    }

    private void UpdateGrowthStage()
    {
        spriteRenderer.sprite = growthStages[currentStage];
    }

    public void Harvest()
    {
        if (currentStage == growthStages.Length - 1)
        {
            foreach (GameObject drop in drops)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}