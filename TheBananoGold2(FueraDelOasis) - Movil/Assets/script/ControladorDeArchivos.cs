using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ControladorDeArchivos : MonoBehaviour
{
    private static string rutAlmacenDat = Application.persistentDataPath; // se optiene la ruta hacia la carpeta donde se aloja los dato
    private  const string nombreArchivo = "PuntajeGlobal.csv";
    // esta funcion permite encontrar la ruta real de un archivo en android
    public static string darFormatoRuta(string nombreArch = nombreArchivo)
    {
        try
        {
            if (Path.IsPathRooted(nombreArch)) { return nombreArch; }
            return Path.Combine(rutAlmacenDat, nombreArch); // retorna la ruta completa que va hacia el archivo
        }
        catch (Exception e)
        {
            Debug.LogError("Error en DarFormato: " + e);
            return Path.Combine(rutAlmacenDat, nombreArchivo); // ruta por defecto
        }
        
    }
    //METODO QUEGUARDA EL PUNTAJE DE JUGADOR EN UNA LISTA DE JUGADORES
    public static void GuardarArchivoMultiple(string archivoN = nombreArchivo, string nombre = "invitado", int puntos = 0)
    {
        archivoN = darFormatoRuta(archivoN);

        if (!(File.Exists(archivoN)) || !BuscarParametro(parametro: nombre))
        {
            //Console.WriteLine("El archivo no existe");
            GuardarGen(puntos, nombre);
            return;
        }
        StreamReader leerArchivo = null;
        leerArchivo = File.OpenText(archivoN);
        string datos;
        string archAuxil = darFormatoRuta("datosAuxiliar.csv");
            if (File.Exists(archAuxil))
            {
                File.Delete(archAuxil);
            }
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
                StreamWriter archivo = File.AppendText(archAuxil);
                archivo.WriteLine(datos);
                archivo.Close();


            }

        }
        while (datos != null); // se repite hasta que el archivo regrese un valor null
        leerArchivo.Close();
        File.Delete(archivoN);
        File.Copy(archAuxil, archivoN, true);
        if (File.Exists(archAuxil))
        {
            File.Delete(archAuxil);
        }
    }

    //METODO PARA BUSCAR UN NOMBRE EN LA LISTA DE JUGADORES
    public static bool BuscarParametro(string archivo = nombreArchivo, string parametro = "")
    {
        try
        {
            archivo = darFormatoRuta(archivo);
            if (string.IsNullOrEmpty(parametro)) { return false; }
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
        archivo = darFormatoRuta(archivo);
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
            archivoN = darFormatoRuta(archivoN);
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
            archivoN = darFormatoRuta(archivoN);
            if (!(File.Exists(archivoN)))
            {
                //Console.WriteLine("El archivo no existe");
                return;
            }
            StreamReader leerArchivo = null;
            leerArchivo = File.OpenText(archivoN);
            string datos;
            string archAuxil = darFormatoRuta("datosAuxiliar.csv");
            if (File.Exists(archAuxil))
            {
                File.Delete(archAuxil);
            }
            do
            {
                datos = leerArchivo.ReadLine();
                if (datos != null)
                {
                    string[] d = datos.Split(",");
                    if (!nombre.Equals(d[0]))
                    {
                        Console.WriteLine("Copiando datos");
                        StreamWriter archivo = File.AppendText(archAuxil);
                        archivo.WriteLine(datos);
                        archivo.Close();
                    }

                }

            }
            while (datos != null); // se repite hasta que el archivo regrese un valor null
            leerArchivo.Close();
            File.Delete(archivoN);
            File.Copy(archAuxil, archivoN, true); // el true permite sobreescribir el archivo si llegara a existir
            if (File.Exists(archAuxil))
            {
                File.Delete(archAuxil);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    public static string ExtrarDatos(string archivoN = nombreArchivo)
    {
        try
        {
            archivoN = darFormatoRuta(archivoN);
            if (!File.Exists(archivoN)) { return null; }
            StreamReader archivoLect = File.OpenText(archivoN);
            string contArchivo = archivoLect.ReadToEnd();
            archivoLect.Close();
            return contArchivo;
        }
        catch (Exception e) { Debug.LogError("Error ExtaerDatos: " + e);  return null; }  
        

    }
}
