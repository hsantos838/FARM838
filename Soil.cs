using UnityEngine;

public class Soil : MonoBehaviour
{
    public Sprite dugSprite;
    public Sprite plantedSprite;
    public bool isDug = false;
    public bool isPlanted = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Dig()
    {
        if (!isDug)
        {
            isDug = true;
            spriteRenderer.sprite = dugSprite;
        }
    }

    public void Plant(GameObject plantPrefab)
    {
        if (isDug && !isPlanted)
        {
            isPlanted = true;
            spriteRenderer.sprite = plantedSprite;
            Instantiate(plantPrefab, transform.position, Quaternion.identity);
        }
    }
}