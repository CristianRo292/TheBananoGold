using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour
{
    public float velocidad_Bala = 50f;
    public GameObject bala_ob;
    public Transform armaP;
    bool est = true;
    public float frecuenciaDeDisparo = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (est)
        {
            StartCoroutine(temporizador(frecuenciaDeDisparo));
        }
       
        
    }
    private void Disparar(Transform arma)
    {

        GameObject clonBala = Instantiate(bala_ob, arma.position, arma.rotation);
        Rigidbody2D cuerpoBala = clonBala.GetComponent<Rigidbody2D>();
        cuerpoBala.velocity = arma.up * velocidad_Bala;
        Destroy(clonBala, 5f);
    }
    IEnumerator temporizador(float tiempo)
    {
        Disparar(armaP);
        est = false;
        yield return new WaitForSeconds(tiempo);
        est = true;
    }
}
