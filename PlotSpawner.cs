using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    public GameObject plotPrefab;
    public LayerMask groundLayer; // Camada que representa o chão onde os plots podem ser colocados
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                Vector3 spawnPosition = hit.point;
                spawnPosition.z = 0; // Garantir que a posição Z seja 0

                Instantiate(plotPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}