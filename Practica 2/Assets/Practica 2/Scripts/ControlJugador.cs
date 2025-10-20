using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    // Movimiento 
    public float velocidad = 5f; // Velocidad del jugador 
    public float gravedad = -9.8f; // Fuerza aplicada de gravedad
    private CharacterController controller; // Controlador de movimiento del jugador
    private Vector3 velocidadVertical; // Vector para registrar velocidad de caída

    // Variables Vista 
    public Transform camara; // Cámara que actúa como "ojos" del jugador 
    public float sensibilidadMouse = 200f; // Qué tan rápido gira el mouse
    private float rotacionXVertical = 0f; // Rotación vertical acumulada

    // Start is called before the first frame update 
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Bloquea el puntero del mouse dentro de la pantalla 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame 
    void Update()
    {
        ManejadorVista();
        ManejadorMovimiento();
    }

    void ManejadorVista()
    {
        // 1. Leer el input del mouse 
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        // 2. Rotación horizontal 
        transform.Rotate(Vector3.up * mouseX);

        // 3. Rotación vertical 
        rotacionXVertical -= mouseY;

        // 4. Limitar la rotación vertical 
        rotacionXVertical = Mathf.Clamp(rotacionXVertical, -90f, 90f);

        // 5. Aplicar la rotación vertical a la cámara 
        camara.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0);
    }

    void ManejadorMovimiento()
    {
        // 1. Leer input de movimiento (WASD)
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // 2. Crear el vector de movimiento local 
        Vector3 direccion = transform.right * inputX + transform.forward * inputZ;

        // 3. Mover el jugador horizontalmente 
        controller.Move(direccion * velocidad * Time.deltaTime);

        // 4. Aplicar la gravedad 
        if (controller.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f; // Mantiene el jugador pegado al suelo
        }

        // 5. Incrementar la velocidad vertical con la gravedad 
        velocidadVertical.y += gravedad * Time.deltaTime;

        // 6. Mover al jugador verticalmente 
        controller.Move(velocidadVertical * Time.deltaTime);
    }
}
