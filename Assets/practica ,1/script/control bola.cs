using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlbola : MonoBehaviour
{
    public Transform CamaraPrincial;
    
    public Rigidbody rb;
    //varaiables para cargar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    public float FuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //expresion.mientras que haSidoLanzada sea falso pues disparar
        if (haSidoLanzada==false)
        {
            Apuntar();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }

    void Apuntar()
    {
        //leer un input Horizontal de tipo Asix, te permite registrar
        //entradas con las teclas A y D , y la flecha izquierda y flecha derecha
        float inputHorizontal = Input.GetAxis("Horizontal");

        //2.mover la bola  hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);
        //3. Demilitar el movimineto de la bola
        //transformposition me permite saber el lugar de la bola 
        Vector3 posicionActual = transform.position;

        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }

    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * FuerzaDeLanzamiento);

        if(CamaraPrincial !=null)
        {
            CamaraPrincial.SetParent(transform);
        }
    }
}// bienvenido al infierno
