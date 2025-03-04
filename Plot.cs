using UnityEngine;

public class Plot : MonoBehaviour
{
    public GameObject plantPrefab;
    private Plant currentPlant;

    void OnMouseDown()
    {
        if (currentPlant == null)
        {
            PlantSeed();
        }
        else if (currentPlant.IsFullyGrown())
        {
            Harvest();
        }
    }

    void PlantSeed()
    {
        GameObject plantObject = Instantiate(plantPrefab, transform.position, Quaternion.identity);
        currentPlant = plantObject.GetComponent<Plant>();
    }

    void Harvest()
    {
        currentPlant.Harvest();
        currentPlant = null;
    }
}