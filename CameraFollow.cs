using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O jogador que a câmera vai seguir
    public float smoothSpeed = 0.125f; // A velocidade de suavização da câmera
    public Vector3 offset; // O deslocamento da câmera em relação ao jogador
    private float initialZ; // Posição inicial no eixo Z

    void Start()
    {
        if (target != null)
        {
            initialZ = transform.position.z; // Armazena a posição inicial no eixo Z
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = initialZ; // Mantém a posição inicial no eixo Z
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}