using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class contadorEnemigos : MonoBehaviour
{
    public static int contadorEnEliminados = 0;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;
    public static int contVidas = 3;
    public GameObject panel;
    public GameObject controles;
    public TextMeshProUGUI txt_enmigosEliminaso;
    public TextMeshProUGUI txt_labelPuntosMeta;
    public int PuntosDeMeta = 6;
    public GameObject celebracionNivel;
    public GameObject personaje;
    public AudioSource musicaDerrota;
    public static string nom = "invitado";
    int puntoslegada;

    // datos del panel en pausa: 
    public GameObject panelPausar;
    public TextMeshProUGUI puntosAlPausar;
    
    // direccion de donde se encuetra el archivo de los puntos 
    private string archPuntaje = string.Empty;

    public static string nombreActual = string.Empty;


    //public InputField input_nombre;
    public TMP_InputField input_nombre;
    // Start is called before the first frame update
    private void Awake()
    {
        try
        {
            print("CONTADOR DE ENEMIMOS EN AWAKE" + contadorEnEliminados.ToString());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            archPuntaje = Path.Combine(Application.persistentDataPath, "Puntaje.csv");
            StreamReader leer;
            if (File.Exists(archPuntaje))
            {
                print("DENTRO DE LA CONDICION AWAKE");
                leer = File.OpenText(archPuntaje);
                string Datos = leer.ReadLine();
                print(Datos);
                string[] p = Datos.Split(",");
                contadorEnEliminados = int.Parse(p[1]);
                puntoslegada = contadorEnEliminados;
                if (p[0].Length != 0) { nombreActual = p[0]; }
                leer.Close();


            }
            print("CONTADOR DE ENEMIMOS EN AWAKE salida" + contadorEnEliminados.ToString());
        }
        catch (Exception e)
        {
            Debug.Log("Error en Awke cont_Enemigo: " + e);
            return;
        }

        

    }
    public void Guardar(int mode = 1)
    {
        try
        {
            //GuardarGen();
            string nomT = string.Empty; // forma optima de inicializar una bariable string
            if (mode == 1) { nomT = input_nombre.text; }
            else if (mode == 0 ) { nomT = nombreActual; }

            print("Contenido de nomt: " + nomT);
            //print("Extencion de nomt: " + nomT.Length);

            if (nomT.Length == 0) 
            { 
                if (nombreActual.Length != 0) { nomT = nombreActual; }
                else { nomT = "invitado"; }
                    
            }

            ControladorDeArchivos.GuardarArchivoMultiple(nombre: nomT, puntos: contadorEnEliminados);
            File.Delete(archPuntaje);
            panel.gameObject.SetActive(false);
            if (mode == 1) { Application.Quit(); }
            
        }
        catch (Exception e)
        {
            Debug.Log("Error en guardar cont_Enemigo: " + e);
            return;
        }
        
        
        

    }
    public void GuardarGen()
    {
        try
        {
            print("CONTADOR DE ENEMIMOS EN GUARDAR GEN " + contadorEnEliminados.ToString());
            if (File.Exists(archPuntaje)) { File.Delete(archPuntaje); }
            
            StreamWriter escribir;
            escribir = File.AppendText(archPuntaje);
            nom = nombreActual;
            if (nom == null || nom.Length == 0)
            {
                nom = "invitado";
            }
            escribir.WriteLine(nom + "," + contadorEnEliminados.ToString());
            //escribir.Write(nom + " , " + contadorEnEliminados.ToString());
            escribir.Close();
            print("CONTADOR DE ENEMIMOS EN GUARDAR GEN SALIDA" + contadorEnEliminados.ToString());
        }
        catch (Exception e)
        {
            Debug.Log("Error en GuardarGen cont_Enemigo: " + e);
            return;
        }
        
    }
    void Start()
    {
        try
        {
            Time.timeScale = 0;
            Time.timeScale = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            panelPausar.SetActive(false);
            panel.gameObject.SetActive(false);
            //celebracionNivel.SetActive(false);
            txt_labelPuntosMeta.text = "/" + PuntosDeMeta.ToString();
            //controles.gameObject.SetActive(true);
            print("CONTADOR DE ENEMIMOS EN SATAR" + contadorEnEliminados.ToString());
        }
        catch (Exception e)
        {
            Debug.Log("Error en start cont_Enemigo: " + e);
            return;
        }
        
        
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
        try
        {
            vidas.text = "X" + contadorEnemigos.contVidas.ToString();
            puntuacion.text = contadorEnemigos.contadorEnEliminados.ToString();
            if (contVidas <= 0)
            {
                //print("no tienes vidas");
                controles.SetActive(false);
                musicaDerrota.Play();
                Time.timeScale = 0;
                panel.SetActive(true);
                //print("se activo el panel");
                txt_enmigosEliminaso.text = contadorEnemigos.contadorEnEliminados.ToString();
                ((TextMeshProUGUI)input_nombre.placeholder).text = nombreActual; // se coloca el nombre actual como texto para el placeholder del campo
                //Guardar(true);
                return;
            }
            else if (contadorEnEliminados >= PuntosDeMeta)
            {
                controles.SetActive(false);
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
                    if (File.Exists(archPuntaje))
                    {
                        File.Delete(archPuntaje);
                    }
                    ControladorDeArchivos.EliminarDeSeccionMultiple(nombre: nom);
                    celebracionNivel.SetActive(true);
                    personaje.SetActive(false);

                }


            }
            //print(contadorEnEliminados);
        }
        catch (Exception e)
        {
            Debug.Log("Error en update cont_Enemigo: " + e);
            return;
        }
        
        
        
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
        try
        {
            print("CONTADOR DE ENEMIMOS EN REINICIAR" + contadorEnEliminados.ToString());
            contadorEnEliminados = puntoslegada;
            GuardarGen();
            contVidas = 3;
            
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            panel.SetActive(false);
            print("CONTADOR DE ENEMIMOS EN REINICIAR SALIDA" + contadorEnEliminados.ToString());
        }
        catch (Exception e)
        {
            Debug.Log("Error en reiniciar cont_Enemigo: " + e);
            return;
        }
        
    }

    public void pausarJuego()
    {
        try
        {
            Time.timeScale = 0;
            puntosAlPausar.text = contadorEnEliminados.ToString();
            panelPausar.SetActive(true);

        }
        catch (Exception e)
        {
            Debug.LogError("Error al Pausar: " + e);
        }
    }

    public void reanudarJuego()
    {
        try
        {
            panelPausar.SetActive(false);
            Time.timeScale = 1;
            

        }
        catch (Exception e)
        {
            Debug.LogError("Error al Pausar: " + e);
        }
    }
   public void salir()
    {
        Application.Quit();
    }
    //public void celebracion()
    //{
    //    Vector3 posicion = new Vector3(-14.21646f, 14.6026f, -1);
    //    GameObject clon = Instantiate(celebracionFu, posicion, Quaternion.identity);
    //    Destroy(clon, 8.0f);
    //}

}
