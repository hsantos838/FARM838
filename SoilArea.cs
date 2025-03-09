using UnityEngine;

public class SoilArea : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.size = new Vector2(16, 16);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soil"))
        {
            Soil soil = collision.GetComponent<Soil>();
            soil.Dig();
        }
    }
}