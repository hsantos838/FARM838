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

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        if (tilemap == null)
        {
            Debug.LogError("Tilemap component not found on " + gameObject.name);
        }
    }

    public void Dig()
    {
        isDug = true;
        Vector3Int tilePosition = tilemap.WorldToCell(transform.position);
        tilemap.SetTile(tilePosition, dugTile);
        Debug.Log("Soil dug at position: " + tilePosition);
    }

    public void Plant(GameObject plantPrefab, Vector3Int tilePosition)
    {
        if (isDug && !isPlanted)
        {
            isPlanted = true;
            tilemap.SetTile(tilePosition, plantedTile);
            Vector3 cellWorldPosition = tilemap.GetCellCenterWorld(tilePosition);
            Instantiate(plantPrefab, cellWorldPosition, Quaternion.identity);
            Debug.Log("Plant planted at position: " + cellWorldPosition);
        }
    }

    public void Water()
    {
        if (isPlanted && !isWatered)
        {
            isWatered = true;
            Vector3Int tilePosition = tilemap.WorldToCell(transform.position);
            tilemap.SetTile(tilePosition, wateredTile);
            Debug.Log("Soil watered at position: " + tilePosition);
        }
    }

    // Adiciona um método público para acessar a tilemap
    public Tilemap GetTilemap()
    {
        return tilemap;
    }
}