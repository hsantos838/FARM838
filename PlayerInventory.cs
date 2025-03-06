using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private int collectedCount = 0;
    public Text collectedCountText;

    void Start()
    {
        // Carrega o saldo de itens coletados salvo anteriormente
        collectedCount = PlayerPrefs.GetInt("CollectedCount", 0);
        UpdateCollectedCountText();
    }

    public void CollectItem()
    {
        collectedCount++;
        // Salva o novo saldo de itens coletados
        PlayerPrefs.SetInt("CollectedCount", collectedCount);
        PlayerPrefs.Save();
        UpdateCollectedCountText();
    }

    private void UpdateCollectedCountText()
    {
        if (collectedCountText != null)
        {
            collectedCountText.text = "Collected Items: " + collectedCount;
        }
    }
}