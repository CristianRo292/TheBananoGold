//using System.Collections;
//using System.Collections.Generic;
//using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class funcionesControles_redireccionamiento : MonoBehaviour
{
    ControlNave funcionesMovimiento = new ControlNave();
    bala controlBala = new bala();
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PresionArriba() => funcionesMovimiento.PresionArriba();
    public void PresionAbajo() => funcionesMovimiento.PresionAbajo();
    public void SoltarEjeY() => funcionesMovimiento.SoltarEjeY(); // Volver a cero al levantar el dedo

    // Eje X (Rotación Izquierda / Derecha)
    public void PresionDerecha() => funcionesMovimiento.PresionDerecha();
    public void PresionIzquierda() => funcionesMovimiento.PresionIzquierda();
    public void SoltarEjeX() => funcionesMovimiento.SoltarEjeX(); // Volver a cero al levantar el dedo

    public void disparar() => controlBala.dispararNuevaBala();
}
