using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ControladorDeArchivos : MonoBehaviour
{
    private  const string nombreArchivo = "PuntajeGlobal.csv";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //METODO QUEGUARDA EL PUNTAJE DE JUGADOR EN UNA LISTA DE JUGADORES
    public static void GuardarArchivoMultiple(string archivoN = nombreArchivo, string nombre = "invitado", int puntos = 0)
    {

        if (!(File.Exists(archivoN)) || !BuscarParametro(parametro: nombre))
        {
            //Console.WriteLine("El archivo no existe");
            GuardarGen(puntos, nombre);
            return;
        }
        StreamReader leerArchivo = null;
        leerArchivo = File.OpenText(archivoN);
        string datos;
        do
        {
            datos = leerArchivo.ReadLine();
            if (datos != null)
            {
                string[] d = datos.Split(",");
                if (nombre.Equals(d[0]))
                {
                   
                    datos = d[0] + "," + puntos.ToString();
                }

                Console.WriteLine("Copiando datos");
                StreamWriter archivo = File.AppendText("datosAuxiliar.csv");
                archivo.WriteLine(datos);
                archivo.Close();


            }

        }
        while (datos != null); // se repite hasta que el archivo regrese un valor null
        leerArchivo.Close();
        File.Delete(archivoN);
        File.Copy("datosAuxiliar.csv", archivoN);
        if (File.Exists("datosAuxiliar.csv"))
        {
            File.Delete("datosAuxiliar.csv");
        }
    }

    //METODO PARA BUSCAR UN NOMBRE EN LA LISTA DE JUGADORES
    public static bool BuscarParametro(string archivo = nombreArchivo, string parametro = "")
    {
        try
        {
            if (parametro == "") { return false; }
            StreamReader archivoLect = File.OpenText(archivo);
            string contArchivo = archivoLect.ReadToEnd();
            archivoLect.Close();
            if (Regex.IsMatch(contArchivo, $@"\b{Regex.Escape(parametro)}\b"))
            {
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            Debug.LogError("Error en Busqueda: " + e);
            return false;
        }
    }
    public static void GuardarGen(int puntos = 0, string nom = "Invidatos", string archivo = nombreArchivo)
    {
        
        StreamWriter escribir;
        escribir = File.AppendText(archivo);
        
        escribir.WriteLine(nom + "," + puntos.ToString());
       
        escribir.Close();
    }

    //METODO PARA RETRONAR EL PUNTAJE DEL JUGADOR BUECADO
    public static int EncontrarDato(string nom = "Invidatos", string archivoN = nombreArchivo)
    {
        try
        {
            StreamReader leerArchivo = null;
            leerArchivo = File.OpenText(archivoN);
            string datos;
            do
            {
                datos = leerArchivo.ReadLine();
                if (datos != null)
                {
                    string[] d = datos.Split(",");
                    if (nom.Equals(d[0]))
                    {
                        //Console.WriteLine("Si lo encontro");
                        return int.Parse(d[1]);
                    }

                }

            }
            while (datos != null); // se repite hasta que el archivo regrese un valor null
            leerArchivo.Close();
            return -1;
        }
        catch (Exception e)
        {
            Debug.LogError("Error al consultar dato: " + e);
            return -1;
        }
    }
    public static void EliminarDeSeccionMultiple(string archivoN = nombreArchivo, string nombre = "")
    {
        try
        {
            if (!(File.Exists(archivoN)))
            {
                //Console.WriteLine("El archivo no existe");
                return;
            }
            StreamReader leerArchivo = null;
            leerArchivo = File.OpenText(archivoN);
            string datos;
            do
            {
                datos = leerArchivo.ReadLine();
                if (datos != null)
                {
                    string[] d = datos.Split(",");
                    if (nombre.Equals(d[0]))
                    {
                        
                    }

                    Console.WriteLine("Copiando datos");
                    StreamWriter archivo = File.AppendText("datosAuxiliar.csv");
                    archivo.WriteLine(datos);
                    archivo.Close();


                }

            }
            while (datos != null); // se repite hasta que el archivo regrese un valor null
            leerArchivo.Close();
            File.Delete(archivoN);
            File.Copy("datosAuxiliar.csv", archivoN);
            if (File.Exists("datosAuxiliar.csv"))
            {
                File.Delete("datosAuxiliar.csv");
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
