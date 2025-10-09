using UnityEngine;

/// <summary>
/// Clase que representa un pino para calcular puntaje.
/// </summary>
public class Pin : MonoBehaviour
{
    // Umbral de inclinaci�n para considerar que el pino ha ca�do
    [SerializeField]
    private float umbralCaida = 5f;

    /// <summary>
    /// Retorna true si el pino est� ca�do.
    /// </summary>
    public bool EstaCaido()
    {
        float angulo = Vector3.Angle(transform.up, Vector3.up);
        return angulo > umbralCaida;
    }
}
