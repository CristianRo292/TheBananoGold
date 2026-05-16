using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reanudarJuego : MonoBehaviour
{
    public TMP_InputField input_nombre;
    public GameObject panelReanudar;
    // Start is called before the first frame update
    void Start()
    {
        panelReanudar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
        
    {
    }
    public void reaunarPartida()
    {
        string nom = input_nombre.text;
        if (!ControladorDeArchivos.BuscarParametro(parametro:nom))
        {
            nom = "invitado";
            
        }
        contadorEnemigos.contadorEnEliminados = ControladorDeArchivos.EncontrarDato(nom);
        panelReanudar.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void ActivarPanel()
    {
        panelReanudar.SetActive(true);
    }

}
