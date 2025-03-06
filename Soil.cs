using UnityEngine;
using UnityEngine.Tilemaps;

public class Soil : MonoBehaviour
{
    public Tile dugTile;
    public Tile plantedTile;
    public Tile wateredTile;
    public bool isDug = false;
    public bool isPlanted = false;
    public bool isWatered = false;

    private Tilemap tilemap;
    private Vector3Int tilePosition;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        if (tilemap == null)
        {
            Debug.LogError("Tilemap component not found on " + gameObject.name);
        }

        tilePosition = tilemap.WorldToCell(transform.position);
    }

    public void Dig()
    {
        if (tilemap == null) return; // Verifica se o Tilemap está presente
        isDug = true;
        tilemap.SetTile(tilePosition, dugTile);
    }

    public void Plant(GameObject plantPrefab)
    {
        if (tilemap == null) return; // Verifica se o Tilemap está presente
        if (isDug && !isPlanted)
        {
            isPlanted = true;
            tilemap.SetTile(tilePosition, plantedTile);
            Instantiate(plantPrefab, tilemap.CellToWorld(tilePosition), Quaternion.identity);
        }
    }

    public void Water()
    {
        if (tilemap == null) return; // Verifica se o Tilemap está presente
        if (isPlanted && !isWatered)
        {
            isWatered = true;
            tilemap.SetTile(tilePosition, wateredTile);
        }
    }
}