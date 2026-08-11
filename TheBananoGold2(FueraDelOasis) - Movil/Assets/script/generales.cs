//using System.Collections;
//using System.Collections.Generic;
using System.IO;
//using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;

public class generales : MonoBehaviour
{
    public string SiguienteEscena = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PasarEscena()
    {
        try
        {
            SceneManager.LoadScene(SiguienteEscena);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); otro metodo para cambiar escena 
        }
        catch
        {
            print("Error al cambiar de escena :(");
        }
    }
    public void siguienteEscena(int noEscena) => SceneManager.LoadScene(noEscena);
    public void volverInicio()
    {
        string archPuntaje = Path.Combine(Application.persistentDataPath, "Puntaje.csv");
        if (File.Exists(archPuntaje)) { File.Delete(archPuntaje); }
        SceneManager.LoadScene(SiguienteEscena);
    }
    
}
