//using System.Collections;
//using System.Collections.Generic;
//using Unity.Collections.LowLevel.Unsafe;
//using Unity.Mathematics;
using UnityEngine;

public class ControlNave : MonoBehaviour 
{
    Rigidbody2D cuerpo_nave;
    float cordX, cordY;
    public int velocidad = 10, velocidadRotacion = 10;
    private Camera camara;
    public float margen = 0.5f;
    public float valorDeLosEjes = 0.65f; // Usamos 1.0f para máxima potencia

    void Start()
    {
        cuerpo_nave = GetComponent<Rigidbody2D>();
        camara = Camera.main;
    }

    void Update()
    {
        // Límites de pantalla (Se mantienen intactos)
        float altura = camara.orthographicSize;
        float ancho = altura * camara.aspect;
        Vector3 posicion = transform.position;

        posicion.x = Mathf.Clamp(posicion.x, -(ancho) + margen, ancho - margen);
        posicion.y = Mathf.Clamp(posicion.y, -(altura) + margen, altura - margen);
        transform.position = posicion;
    }

    void FixedUpdate()
    {
        // El movimiento se aplica de forma continua mientras las variables no sean 0
        cuerpo_nave.velocity = transform.up * velocidad * cordY;
        cuerpo_nave.angularVelocity = -(cordX) * velocidadRotacion * 100;
    }

    // --- MÉTODOS PARA EL EVENT TRIGGER (Detectan presión constante) ---

    // Eje Y (Avanzar / Retroceder)
    public void PresionArriba() => cordY = valorDeLosEjes;
    public void PresionAbajo() => cordY = -valorDeLosEjes;
    public void SoltarEjeY() => cordY = 0f; // Volver a cero al levantar el dedo

    // Eje X (Rotación Izquierda / Derecha)
    public void PresionDerecha() => cordX = valorDeLosEjes;
    public void PresionIzquierda() => cordX = -valorDeLosEjes;
    public void SoltarEjeX() => cordX = 0f; // Volver a cero al levantar el dedo
}
