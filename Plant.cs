using UnityEngine;

public class Plant : MonoBehaviour
{
    public Sprite[] growthStages;
    public float timeBetweenStages = 5f;
    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = growthStages[currentStage];
        timer = timeBetweenStages;
    }

    void Update()
    {
        if (currentStage < growthStages.Length - 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentStage++;
                spriteRenderer.sprite = growthStages[currentStage];
                timer = timeBetweenStages;
            }
        }
    }

    public void Harvest()
    {
        if (currentStage == growthStages.Length - 1)
        {
            // Adicione a lógica de colheita aqui (por exemplo, adicionar recompensas ao jogador)
            Destroy(gameObject);
        }
    }
}