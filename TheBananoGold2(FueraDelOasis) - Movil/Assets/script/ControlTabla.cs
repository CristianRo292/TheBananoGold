//using Microsoft.Unity.VisualStudio.Editor;
using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using Color = UnityEngine.Color;

public class ControlTabla : MonoBehaviour
{
    public GameObject[] Paneles;
    public TextMeshProUGUI[] Nombres;
    public TextMeshProUGUI[] Puntos;
    public static int PosicionVigente = 0;
    int PosicionMaxima = 0;
    public GameObject Advertencia = null;
    public static int celdaSeleccionada = 0;
    //public TextMeshProUGUI AdvertenciaTex = null;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in Paneles)
        {
            item.SetActive(false);
        }
        cargarTabla();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void extraerDatos()
    {
        //print("Datos0");



    }
    public void cargarTabla()
    {
        string[] datos;
        try
        {
            datos = ControladorDeArchivos.ExtrarDatos().Split("\n");
            PosicionMaxima = datos.Length;

        }
        catch (Exception e)
        {
            PosicionMaxima = 0;
            foreach (var item in Paneles)
            {
                item.SetActive(false);
            }
            return;
        }
        
        
        string[] Participante;
        int cont = 0;
        for (int i = PosicionVigente; ( i <= PosicionVigente + 5); i++)
        {
            if (datos[i].Length == 0)
            {
                try
                {
                    while (cont < Paneles.Length)
                    {
                        Paneles[cont].SetActive(false);
                        cont++;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Debug.Log("Fayo el while, Cargar Tabla" + e);
                }

            }
            Debug.Log("dato del contador: " + cont + "Dato de i: " + i);
            Participante = datos[i].Split(",");
            Paneles[cont].SetActive(true);
            Nombres[cont].text = Participante[0];
            Puntos[cont].text = Participante[1];
            cont++;

        }
    }
    public void retrocederTabla()
    {
        
        PosicionVigente = PosicionVigente - 6;
        if (PosicionVigente <= 0) { PosicionVigente = 0; }
        cargarTabla();
    }
    public void avanzarTabla()
    {
        PosicionVigente = PosicionVigente + 6;
        if (PosicionVigente >= PosicionMaxima) { PosicionVigente = PosicionVigente - 6; }
        cargarTabla();
    }
    public void ActivarAdvertencia()
    {
        Advertencia.SetActive(true);

    }
    public void ElimiarSeleccion() => ControladorDeArchivos.EliminarDeSeccionMultiple(nombre: Nombres[celdaSeleccionada].text); // se optiene el nobre que esta alamecendp en el panel con el ID que se esta seleccionadndo
    public void seleccionarCelTabla(int IDCelda = 0)
    {
        celdaSeleccionada = IDCelda;
        Image nuevaimegen = Paneles[IDCelda].GetComponent<Image>();
        nuevaimegen.color = Color.yellow;
    }
    public void SalirCelda(int IDCelda = 0)
    {
        Image nuevaimegen = Paneles[IDCelda].GetComponent<Image>();
        nuevaimegen.color = Color.white;
    }
    public void comenzarDesdeRegistro()
    {
        string nom = Nombres[celdaSeleccionada].text;
        contadorEnemigos.contadorEnEliminados = ControladorDeArchivos.EncontrarDato(nom);
        contadorEnemigos.nombreActual = Nombres[celdaSeleccionada].text;

        //panelReanudar.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}




