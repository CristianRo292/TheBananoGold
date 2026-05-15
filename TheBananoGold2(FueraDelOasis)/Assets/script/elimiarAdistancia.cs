using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elimiarAdistancia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            contadorEnemigos.IncrementarEnemigo();
            Destroy(collision.gameObject);

        }
        else if (collision.CompareTag("Player"))
        {
            contadorEnemigos.DescontarVidas();
        }
        else
        {
            return;
        }
        Destroy(gameObject);
    }
}
