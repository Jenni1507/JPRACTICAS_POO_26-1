using UnityEngine;
using UnityEngine.UI; // Necesario para usar el componente Text

public class ScoreManager : MonoBehaviour
{
    // Texto UI
    public Text textoPuntaje;

    // Puntaje interno
    private int puntajeActual = 0;

    [SerializeField]
    private Pin[] pinos;

    void Start()
    {
        // Mensaje inicial
        if (textoPuntaje != null)
            textoPuntaje.text = "Tienes un millón de dólares";

        // Buscar todos los objetos tipo Pin
        pinos = FindObjectsOfType<Pin>();
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        if (pinos != null)
        {
            foreach (Pin pin in pinos)
            {
                if (pin != null && pin.EstaCaido())
                {
                    puntaje++;
                }
            }
        }

        puntajeActual = puntaje;

        if (textoPuntaje != null)
            textoPuntaje.text = "Pinos caídos: " + puntajeActual;
    }
}
