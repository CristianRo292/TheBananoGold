using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class contadorEnemigos : MonoBehaviour
{
    public static int contadorEnEliminados = 0;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;
    public static int contVidas = 3;
    public GameObject panel;
    public TextMeshProUGUI txt_enmigosEliminaso;
    public TextMeshProUGUI txt_labelPuntosMeta;
    public int PuntosDeMeta = 6;
    public GameObject celebracionNivel;
    public GameObject personaje;
    public AudioSource musicaDerrota;
    public static string nom = "invitado";


    //public InputField input_nombre;
    public TMP_InputField input_nombre;
    // Start is called before the first frame update
    private void Awake()
    {
        
        StreamReader leer;
        if (File.Exists("Puntaje.csv"))
        {
            leer = File.OpenText("Puntaje.csv");
            string Datos = leer.ReadLine();
            string[] p = Datos.Split(",");
            contadorEnEliminados = int.Parse(p[1]);
            leer.Close();
            

        }
        

    }
    public void Guardar()
    {
        //GuardarGen();
        string nomT = input_nombre.text;
        if (nomT.Length == 0) { nomT = "invitado"; } 
        ControladorDeArchivos.GuardarArchivoMultiple(nombre:nomT , puntos: contadorEnEliminados);
        File.Delete("Puntaje.csv");
        panel.gameObject.SetActive(false);
        Application.Quit();
        
        

    }
    public void GuardarGen()
    {
        File.Delete("Puntaje.csv");
        StreamWriter escribir;
        escribir = File.AppendText("Puntaje.csv");
        nom = input_nombre.text;
        if (nom == null)
        {
            nom = "invitado";
        }
        escribir.WriteLine(nom + "," + contadorEnEliminados.ToString());
        //escribir.Write(nom + " , " + contadorEnEliminados.ToString());
        escribir.Close();
    }
    void Start()
    {
        panel.gameObject.SetActive(false);
        celebracionNivel.SetActive(false);
        txt_labelPuntosMeta.text = "/" + PuntosDeMeta.ToString();
        
        //if (SceneManager.GetActiveScene().buildIndex == 3)
        //{
        //    StartCoroutine(celebrarInicioNivel(2.0f));
        //}
    }

    //IEnumerator celebrarInicioNivel(float tiempo)
    //{
    //    celebracionNivel.SetActive(true);
    //    personaje.SetActive(false);
    //    yield return new WaitForSeconds(tiempo);
    //    celebracionNivel.SetActive(false);
    //    personaje.SetActive(true);
    //}

    // Update is called once per frame
    void Update()
    {
        vidas.text = "X" + contadorEnemigos.contVidas.ToString();
        puntuacion.text = contadorEnemigos.contadorEnEliminados.ToString();
        if (contVidas <= 0)
        {
            //print("no tienes vidas");
            musicaDerrota.Play();
            Time.timeScale = 0;
            panel.SetActive(true);
            print("se activo el panel");
            txt_enmigosEliminaso.text =contadorEnemigos.contadorEnEliminados.ToString();
            //Guardar(true);
            return;
        }
        else if (contadorEnEliminados >= PuntosDeMeta)
        {
            // hacer animacion de la nave creciendo y volando

            //celebracion sigEsc = new celebracion();
            //sigEsc.InciarInterrupcion();
            int proximaEscena = SceneManager.GetActiveScene().buildIndex + 1;
            if (proximaEscena < SceneManager.sceneCountInBuildSettings)
            {
                GuardarGen();
                SceneManager.LoadScene(proximaEscena);
            }
            else
            {
                File.Delete("Puntaje.csv");
                ControladorDeArchivos.EliminarDeSeccionMultiple(nombre: nom);
                celebracionNivel.SetActive(true);
                personaje.SetActive(false);
                
            }
            

        }
            print(contadorEnEliminados);
        
        
    }
    
    public static void IncrementarEnemigo()
    {
        contadorEnEliminados ++;
    }
    public static void DescontarVidas()
    {
        contVidas--;
    }
    public void reiniciar()
    {
        GuardarGen();
        contVidas = 3;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
    }
    //public void celebracion()
    //{
    //    Vector3 posicion = new Vector3(-14.21646f, 14.6026f, -1);
    //    GameObject clon = Instantiate(celebracionFu, posicion, Quaternion.identity);
    //    Destroy(clon, 8.0f);
    //}

}
